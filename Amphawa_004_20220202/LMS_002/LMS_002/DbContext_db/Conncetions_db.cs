using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS_002.DbContext_db
{
    public sealed class Conncetions_db
    {
        //ถ้าเข้าใช้ class นี้ตอนแรก ยังไงก็ null
        private static Conncetions_db instance = null;

        //กันไม่ให้ new object
        private Conncetions_db()
        {
        }

        //เรียก class นี้ผ่าน properties นี้เท่านั้น
        public static Conncetions_db Instance
        {
            //มา get ค่ากัน
            get
            {
                //ถ้า มีการใช้ method class นี้ มันจะไป new object นี้โดยไม่ต้อง new 
                //ที่อื่นอีก
                if (instance == null)
                {
                    instance = new Conncetions_db();
                }
                return instance;
            }
        }

        public  DataTable Connection_command(string cmd)
        {

            using (SqlConnection cl_con = new SqlConnection(ConfigurationManager.ConnectionStrings["amphawacontect"].ConnectionString))
            {
                
                DataTable dt = new DataTable();
                SqlCommand command = new SqlCommand(cmd, cl_con);
               
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(dt);
                cl_con.Close();
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    if(dt.Columns.Count < 0)
                    {
                        dt.Columns.Add(new DataColumn() { ColumnName = "test" });
                        dt.Rows.Add("0");
                    }
                   

                    return dt;
                   
                }

                return dt;

            }
        }

        
    }

}