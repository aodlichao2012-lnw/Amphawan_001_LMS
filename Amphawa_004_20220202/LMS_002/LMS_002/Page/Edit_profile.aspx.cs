using LMS_002.DbContext_db;
using LMS_002.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Page
{
    public partial class Edit_profile : System.Web.UI.Page
    {
        MD_Account md_account = new MD_Account();
        string user_ = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["user"] != null)
                {
                    user_ = Session["user"].ToString();
                }
                using (var db_ = new Dbcon_wan())
                {
                    md_account = db_.tb_account.Where(a => a.st_user == user_).FirstOrDefault();
                    Session["id_Accont"] = md_account.int_id;
                    txt_login.Value = md_account.st_user;
                    txt_password.Value = md_account.st_password;
                    txt_Email.Value = md_account.st_email;
                    txt_address.Value = md_account.st_post_address;
                    txt_name.Value = md_account.st_cus_name;
                    txt_address.Value = md_account.st_post_address;
                    
                }
            }
        }

        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            using (var db = new Dbcon_wan())
            {
                try
                {

                    string st_post_address = txt_address.Value;
                    string st_cus_name = txt_name.Value;
                    string user = txt_login.Value;
                    string st_password = txt_password.Value;
                    string st_email = txt_Email.Value;
                    Session["user"] = user;
                    var cs = Conncetions_db.Instance.Connection_command(@" UPDATE [dbo].[MD_Account] SET st_user = '" + user + "' , " +
                          "st_password = '" + st_password + "' , st_email = '" + st_email + "' , st_cus_name = '" + st_cus_name + "' , st_post_address" +
                          " = '" + st_post_address + "'   where int_id = " + Session["id_Accont"].ToString() + " ");
                    Response.Write(@"<script>alert('บันทึกเรียบร้อย')</script>");
                    Response.Redirect(@"~/Page/Role_Admin.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write(@"<script>alert('บันทึกเรียบร้อย')</script>");
                    Response.Redirect("~/Page/List_book.aspx");
                }
            }
        }

        protected void btn_back_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Page/List_book.aspx");
        }
    }
}