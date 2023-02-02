using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace learn
{
    class ConnectDB
    {
        public static SqlConnection connectDB()
        {
            string connectStr = "Data Source=localhost,1433;Initial Catalog=QLNV;User ID=sa;Password=1234";
            try
            {
                var sqlConnection = new SqlConnection(connectStr);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.Message);

            }
            return null;

        }
       
        public static void insertData(string name, string passWord)
        {
            string query = "insert into Account(name,password) values (@name,@pass)";
            SqlCommand command = new SqlCommand();

            command.Connection = connectDB();
            command.CommandText = query;
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@pass", passWord);

            var result = command.ExecuteNonQuery();
            Console.WriteLine(result);
            connectDB().Close();
        }
        public static void getAllCart()
        {
            string query = "select * from getCart()";
            SqlCommand command = new SqlCommand();
            command.Connection = connectDB();
            command.CommandText = query;
            using var reader = command.ExecuteReader();
            if(reader.HasRows){
                while(reader.Read()){
                    var nameCart = reader["cardName"];
                    Console.WriteLine(nameCart);

                }
            }
        }
        public static void DeleteDepartMent(int DEPT_ID){
            string query = "delete from  DEPARTMENT WHERE DEPT_ID = @DEPT_ID";
            using (SqlCommand command = new SqlCommand()){
                command.Connection = connectDB();
                command.CommandText = query;
                SqlParameter sqlParameter = new SqlParameter("@DEPT_ID",DEPT_ID);
                
                command.ExecuteNonQuery();

            }
        }




    }
};