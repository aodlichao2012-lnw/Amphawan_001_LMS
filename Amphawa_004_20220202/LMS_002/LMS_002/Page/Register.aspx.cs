
using System;
using LMS_002.DbContext_db;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS_002.Models;

namespace LMS_002.Page
{
    public partial class Register : System.Web.UI.Page
    {
        MD_Account md_account = new MD_Account();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_save_ServerClick(object sender, EventArgs e)
        {

            if (txt_login.Value != "" && txt_password.Value == txt_compare.Value)
            {
                using (var db = new Dbcon_wan())
                {
                    md_account.st_user = txt_login.Value;
                    md_account.st_password = txt_password.Value;
                    md_account.st_email = txt_Email.Value;
                    md_account.st_cus_name = txt_name.Value;
                    md_account.st_post_address = txt_address.Value;
                    var result = db.tb_account.Any(s => s.st_user == txt_login.Value);
                    if (result)
                    {
                        Response.Write(@"<script>alert('มีผู้ใช้อยู่แล้ว')</script>");
                    }
                    else
                    {
                        md_account.int_type_cus = Convert.ToInt32(ddl_role.SelectedValue);
                        md_account.st_type_cus = ddl_role.SelectedItem.Text;

                        db.tb_account.Add(md_account);
                        db.SaveChanges();
                        Response.Write(@"<script>alert('บันทึกเรียบร้อย')</script>");
                        Response.Redirect(@"~/Page/Login.aspx");
                    }


                }

            }
            else
            {
                Response.Write(@"<script>alert('กรุณากรอกข้อมูลให้ครบ')</script>");
            }
        }

        protected void btn_back_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Page/Login.aspx");
        }
    }
}