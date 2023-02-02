// using System.Data;
// using System.Data.SqlClient;
// using System.Text;

// namespace learn {
//     class ConnectDiemSV {
//         public static SqlConnection ConnectDb(){
//                string connectStr = "Data Source=localhost,1433;Initial Catalog=QuanLyDiemSV;User ID=sa;Password=1234";
        

//                try   {
//                         SqlConnection sql = new SqlConnection(connectStr);
//                           sql.Open();
//                 return sql;


//             }
//                catch (Exception e)
//                 {
//                     System.Console.WriteLine(e.Message);
//                 }return null;

//         }
//           public static DataTable Load(string query){
//             DataTable dt = new DataTable();
//             SqlCommand cmd = new SqlCommand();
//             cmd.CommandText = query;
//             cmd.Connection = ConnectDb();
//             SqlDataAdapter da = new SqlDataAdapter();
//             da.SelectCommand = cmd;
//             da.Fill(dt);
//             dt.AcceptChanges();
//             ConnectDb().InfoMessage += connection_InfoMessage;
//             return dt;
//         }
//         public static DataTable query(string PROCE , Object[] ob){
//             StringBuilder query = new StringBuilder($"EXEC {PROCE} ");
//             foreach(var item in ob){
//                 query.Append(" " + item).Append(" ,");
//             }
          
//             string queryStr = query.ToString().Substring(0, query.Length - 1);
//             DataTable dt = Load(queryStr);
//             System.Console.WriteLine(queryStr);

//             return dt;
//         }
//         public static void findSinhVien(){
//             string PROCE = "findSVByIdAndMaKhoa";
//             Object[] ob = { "A01", "TH" };
//             DataTable dt = query(PROCE, ob);
//              foreach(DataRow rows in dt.Rows){
//                 System.Console.WriteLine($"{rows["MaSV"]} : {rows["TenSV"]}");
//             }

//         }

//            public static void findIdSV(){
//             string PROCE = "findIdSV";
//             Object[] ob = { "A01", ParameterDirection.Output };
//             DataTable dt = query(PROCE, ob);
//              foreach(DataRow rows in dt.Rows){
//                 // System.Console.WriteLine($"{rows["MaSV"]} : {rows["TenSV"]}");
//                 System.Console.WriteLine($"{rows["IdsList"]}");
//             }

//         }
//         public static void MessageInfo (){
//             string query = "MessageInfo";
//             Load(query);

//         }
       
//         public static void CRUD(SinhVien sv){
//             System.Console.WriteLine("Xin chao");
//             string query = "EXEC CRUDPSV @P_WORKTYPE,@MA_SV,@HO_SV,@TEN_SV,@HOC_BONG";
//             SqlCommand cmd = new SqlCommand();
//             cmd.CommandText = query;
//             cmd.Connection = ConnectDb();
            

//             cmd.Parameters.Add(SetParam("@P_WORKTYPE", sv.WORKTYPE));
//             cmd.Parameters.Add(SetParam("@MA_SV", sv.MaSV));
//             cmd.Parameters.Add(SetParam("@HO_SV", sv.HoSV));
//             cmd.Parameters.Add(SetParam("@TEN_SV",sv.TenSv));
//             cmd.Parameters.Add(SetParam("@HOC_BONG", sv.HocBong.ToString()));
        
//             System.Console.WriteLine($"{sv.WORKTYPE} : {sv.MaSV}");
            
//             var a = cmd.ExecuteScalar();
//             System.Console.WriteLine($"gia tri duoc then la {a}");
      
//             ConnectDb().Close();
//         }
//          public static void CheckType(string param,dynamic ob){
         
//             SqlParameter Sqlparam = new SqlParameter();
           
//              Sqlparam.ParameterName = param;
//             if(typeof(int) == ob.GetType()){
//                 Sqlparam.SqlDbType = SqlDbType.Int;
//             }
//             else if (typeof(string) == ob.GetType()){
//                 Sqlparam.SqlDbType = SqlDbType.BigInt;
//             }
//            else if (typeof(float) == ob.GetType()){
//                 Sqlparam.SqlDbType = SqlDbType.Float;

//             }
//             else if (typeof(DateTime) == ob.GetType()){
//                 Sqlparam.SqlDbType = SqlDbType.DateTime;
//             }else {
//                 Sqlparam.SqlDbType = SqlDbType.Text;
//             }

//             if (String.IsNullOrEmpty(ob)){
//                 Sqlparam.Value = DBNull.Value;
//             }else {
//                 Sqlparam.ParameterName = ob;
//             }
          
           
//         }
//         public static SqlParameter SetParam(string paramName,string param){
//             SqlParameter sqlp = null;
          
//             if(String.IsNullOrEmpty(param)){
//                 sqlp = new SqlParameter(paramName, DBNull.Value);
                
//             }else{
//                 sqlp = new SqlParameter(paramName, param);
              
//             }
//             return sqlp;
//         }

//            static void connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
//         {
//             // this gets the print statements (maybe the error statements?)
//             var outputFromStoredProcedure = e.Message;              
//         }


//     }
// }