using System.Data.SqlClient;
using System.Data;
using learn;
using System.Reflection;

class ReflectionDB<T> {
    public static DataTable Procedure(String storeProcedureName, Object ?dto = null)
    {

       string connectStr = "Data Source=localhost,1433;Initial Catalog=QLSV;User ID=sa;Password=1234";
        DataTable dataTable = new DataTable();
    using (SqlConnection connection = new SqlConnection(connectStr))
    {
    connection.Open();
    using (SqlCommand command = new SqlCommand(storeProcedureName,connection))
    {
        command.CommandType = CommandType.StoredProcedure;
        if(dto != null){
        foreach (var property in dto.GetType().GetProperties())
        {
            if (!String.IsNullOrEmpty(property.GetValue(dto)?.ToString()))
            {
                string paramName = "@" + property.Name;
                object ?paramValue = property.GetValue(dto);
                command.Parameters.Add(new SqlParameter (paramName,paramValue));
            }
        }
        }
       
        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
        {
            dataAdapter.Fill(dataTable);
        }
      }
    }

        return dataTable;
    }




    public static void findSinhVien(){
        string proc = "findSinhVien";
        SinhVien sv = new SinhVien
        {
            MaSV = "001"
        };
       DataTable dt =  Procedure(proc);
        List<Data> list = DataBinding<Data>(dt); 

    }
    public static List<T> DataBinding(DataTable dataTable){

        List<T> list = new List<T>();
        foreach (DataRow row in dataTable.Rows)
        {
            T item = (T)Activator.CreateInstance(typeof(T));

            foreach (DataColumn column in dataTable.Columns)
            {
                item.GetType().GetProperties();
                PropertyInfo property = typeof(T).GetProperty(column.ColumnName);
                if(property == null ){
                    System.Console.WriteLine($"Property with name {column.ColumnName} not match in Data Class");
                    continue;
                }

                if (property.CanWrite)
                {
                   
                    property.SetValue(item, row[column]);
                }
                  

            }
               list.Add(item);
        }
        return list;
    }
  
}