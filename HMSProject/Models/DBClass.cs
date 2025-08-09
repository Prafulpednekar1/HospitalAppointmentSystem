using System.Collections.Generic;
using System.Data;


namespace HMSProject.Models
    {
        public class DBClass
        {
        string constr = "Data Source=DESKTOP-GBC84KB\MSSQLSERVER01;Initial Catalog=HMSDB;Integrated Security=True;Trust Server Certificate=True";

            public void ExecuteNonQuery(string query)
            {
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            public DataTable GetTable(string query)
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
 
