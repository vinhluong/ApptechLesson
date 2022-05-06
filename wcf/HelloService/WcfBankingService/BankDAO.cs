using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WcfBankingService
{
   public class BankDAO
    {
        public SqlConnection ConnectDB()
        {
            //khai báo lớp SqlConnection có chuỗi kết nối với CSDL SQL Server
            SqlConnection connection = new SqlConnection("data source=KV1-HT-0983-1\\VINHLTDB; database=WcfDatabase; integrated security=true");
            //khai báo lớp SqlCommand để chèn câu lệnh Query vào SQL Server

            //mở chuỗi kết nối tới CSDL
            connection.Open();
            //sử dụng phương thức SqlDataReader để truy xuất dữ liệu từ CSDL
            return connection;
        }
        public DataSet ExecuteQuery(SqlConnection connection,  string query)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = connection)
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    cn.Close();
                }
            }
            return ds;
        }
    }
}
