using LMS_002.DbContext_db;
using LMS_002.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Page
{
    public partial class Login : System.Web.UI.Page
    {
        MD_Account md_account = new MD_Account();

        protected void Page_Load(object sender, EventArgs e)
        {
            Conncetions_db.Instance.Connection_command($@"UPDATE dbo.MD_Account SET status = 0 WHERE st_user IN (
                                                            SELECT st_user FROM dbo.MD_Account WHERE dt_cus_expire_cus_day < GETDATE() )");

            //using (var db = new Dbcon_wan())
            //{
            //    var cs = db.tb_account.ToList();
            //}
            this.Page.SetFocus(txt_login.ClientID);
            if (Session["user"] == null)
            {
                formContent.Visible = true;

            }
            else if (Session["roleid"] != null)
            {
                formContent.Visible = false;
            }
        }
        protected void btn_save_ServerClick1(object sender, EventArgs e)
        {
            if (txt_login.Value != "")
            {
                using (var db = new Dbcon_wan())
                {

                    var result = db.tb_account.Any(s => s.st_user == txt_login.Value && s.st_password == txt_password.Value && s.dt_cus_expire_cus_day > DateTime.Now);
                    //var result = Conncetions_db.Instance.Connection_command($@"SELECT * FROM MD_Account WHERE st_user = '{txt_login.Value}' AND  st_password = '{txt_password.Value}'");
                    if (result)
                    {
                        Session["user"] = txt_login.Value;
                        //Session["roleid"] = Conncetions_db.Instance.Connection_command($@"SELECT int_type_cus FROM  MD_Account WHERE st_user = '{txt_login.Value}'");
                        Session["roleid"] = db.tb_account.Where(c => c.st_user == txt_login.Value).Select(a => a.int_type_cus).FirstOrDefault();
                        Response.Redirect(@"~/Page/List_book.aspx");
                    }
                    else
                    {
                        Session["role"] = 3;
                        Response.Redirect(@"~/Page/Login.aspx");
                    }

                }
            }


            else
            {
                Response.Write(@"<script>alert('กรุณากรอกข้อมูลให้ครบ')</script>");
            }
        }
    }
}