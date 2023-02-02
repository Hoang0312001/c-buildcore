using System.Data;
using System.Data.SqlClient;

namespace learn
{
    class ConnectWMS_MES{
      public static SqlConnection connect(){
          string conn = "Persist Security Info=True;Data Source=10.10.31.20,61433;User ID=vinames;Password=vina@9876#;Initial Catalog=NH_MES;";
        //   string conn = "Data Source=localhost,1433;Initial Catalog=QuanLyDiemSV;User ID=sa;Password=1234";
            try{
                SqlConnection sql = new SqlConnection(conn);
                sql.Open();
                return sql;
            }catch(Exception e){
                System.Console.WriteLine(e.Message);
            }
            return null;

        }

        public static DataTable Load(string query){
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connect();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dt.AcceptChanges();
            return dt;
        }
        public static void FindAll(){
            string sql = "select * from T_M_CUSTOMER";
            DataTable dt = Load(sql);
            foreach(DataRow rows in dt.Rows){
                System.Console.WriteLine($"{rows["CUST_ID"]} : {rows["CUST_HNAME"]}");
            }
            
        }
     
    }
}