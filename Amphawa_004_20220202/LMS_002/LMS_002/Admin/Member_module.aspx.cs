using LMS_002.DbContext_db;
using LMS_002.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Admin
{
    public partial class Member_module : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        string sql = "";
        string profile = "";
        string count_book = "";
        string img_book = "";
        string id_book = "";
        string user_ = "";
        MD_Account md_account = new MD_Account();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Conncetions_db.Instance.Connection_command($@"UPDATE dbo.MD_Account SET status = 0 WHERE st_user IN (
                                                            SELECT st_user FROM dbo.MD_Account WHERE dt_cus_expire_cus_day < GETDATE() )");
                gdv_Role_admin.DataSource = Conncetions_db.Instance.Connection_command("SELECT [status] , [int_id], [st_user], [st_email], [st_type_cus] FROM [MD_Account] where st_user != 'suparat004' ");
                gdv_Role_admin.DataBind();
            }
        }

        protected void gdv_Role_admin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(gdv_Role_admin.DataKeys[index].Value.ToString());
            if (e.CommandName == "edit")
            {
                pn_edit_role.Visible = true;
                gdv_Role_admin.Visible = false;
                if (Session["user"] != null)
                {
                    user_ = Session["user"].ToString();
                }
                Session["add"] = 0;
                using (var db_ = new Dbcon_wan())
                {
                    md_account = db_.tb_account.Where(a => a.int_id == id).FirstOrDefault();
                    Session["id_Accont"] = md_account.int_id;
                    txt_login.Value = md_account.st_user;
                    txt_password.Value = md_account.st_password;
                    txt_Email.Value = md_account.st_email;
                    txt_address.Value = md_account.st_post_address;
                    txt_name.Value = md_account.st_cus_name;
                    ddl_role.SelectedValue = md_account.int_type_cus.ToString();
                }
            }
            else if (e.CommandName == "delete")
            {
                try
                {
                    using (var db_ = new Dbcon_wan())
                    {
                        var ids = db_.tb_account.Where(a => a.int_id == id).Select(a => a.st_user).FirstOrDefault();
                        var update = Conncetions_db.Instance.Connection_command(@"UPDATE [dbo].[MD_catralog_book] SET  [int_cheeckin_out] = 0 ,[st_cheeckin_out] = 'พร้อมยืม' , st_process_name_user
                           = '' WHERE st_process_name_user = '" + ids + "'");
                        var result = Conncetions_db.Instance.Connection_command("delete from [dbo].[MD_Account] where int_id = " + id + "");
                        gdv_Role_admin.DataSource = Conncetions_db.Instance.Connection_command("SELECT [int_id], [st_user], [st_email], [st_type_cus] FROM [MD_Account] where st_user != 'suparat004' ");
                        gdv_Role_admin.DataBind();
                        Response.Write(@"<script>alert('ลบเรียบร้อย')</script>");
                    }
                }
                catch
                {
                 
                    Response.Redirect("~/Page/Role_Admin.aspx");
                }

            }
        }



        protected void doSearch_ServerClick(object sender, EventArgs e)
        {

            string select = $@"SELECT [status] ,  [int_id], [st_user], [st_email], [st_type_cus] FROM [MD_Account] 
                                                                   WHERE {Types.Value} LIKE 
                                                                 ";

            gdv_Role_admin.DataSourceID = null;
            List<MD_catralog_book> cs = new List<MD_catralog_book>();
            if (Types.Value != "")
            {
                if (keywords.Value != "")
                {
                    switch (Types.Value)
                    {
                        case "st_user":
                            select += $" '%{ keywords.Value }%' ";

                            break;
                        case "st_type_cus":
                            select += $" '%{ keywords.Value }%' ";
                            break;

                    }
                    dt = Conncetions_db.Instance.Connection_command(@"" + select + "");
                }
                else
                {
                    dt = Conncetions_db.Instance.Connection_command(@"SELECT [status],  [int_id], [st_user], [st_email], [st_type_cus] FROM[MD_Account] ");
                }
                gdv_Role_admin.DataSource = dt;
                gdv_Role_admin.DataBind();
            }
        }

        protected void btn_back_ServerClick(object sender, EventArgs e)
        {

            pn_edit_role.Visible = false;
            gdv_Role_admin.Visible = true;
        }

        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            if (txt_login.Value != "" && txt_password.Value == txt_compare.Value)
            {
                using (var db = new Dbcon_wan())
                {
                    try
                    {


                        string user = txt_login.Value;
                        string st_password = txt_password.Value;
                        string st_email = txt_Email.Value;
                        string st_type_cus = ddl_role.SelectedItem.Text;
                        string st_name = txt_name.Value;
                        string st_adress = txt_address.Value;
                        int int_type_cus = ddl_role.SelectedValue.ToString().Equals("") ? 3 : Convert.ToInt32(ddl_role.SelectedValue.ToString());
                        if (Session["user"].ToString() == user)
                        {
                            Session["user"] = user;
                        }
                        if (Convert.ToInt32( Session["add"]) == 1)
                        {
                            var cs = Conncetions_db.Instance.Connection_command($@"INSERT INTO [dbo].[MD_Account]
                                               ([st_user]
                                               ,[st_password]
                                               ,[st_email]
                                               ,[dt_cus_begin_cus_day]
                                               ,[dt_cus_expire_cus_day]
                                               ,[st_cus_name]
                                               ,[st_post_address]
                                               ,[st_Email_address]
                                                , [int_type_cus]
                                                , [st_type_cus]
		                                       )
                                         VALUES
                                               ('{user}'
                                               ,'{st_password}'
                                               ,'{st_email}'
                                               ,GETDATE()
                                               ,'{DateTime.Now.AddMonths(2).ToString()}'
                                               ,'{st_name}'
                                               ,'{st_adress}'
                                               ,'{st_email}'
                                                , {int_type_cus}
                                                , '{st_type_cus}'
		                                       )
                                    ");
                            Response.Write(@"<script>alert('บันทึกเรียบร้อย')</script>");
                            pn_edit_role.Visible = false;
                            gdv_Role_admin.Visible = true;
                            gdv_Role_admin.DataSource = Conncetions_db.Instance.Connection_command("SELECT [status] ,  [int_id], [st_user], [st_email], [st_type_cus] FROM [MD_Account] where st_user != 'suparat004' ");
                            gdv_Role_admin.DataBind();
                        }
                        else if(Convert.ToInt32(Session["add"]) == 0)
                        {
                            var cs = Conncetions_db.Instance.Connection_command(@" UPDATE [dbo].[MD_Account] SET st_user = '" + user + "' , " +
                             "st_password = '" + st_password + "' , st_cus_name = '" + st_name + "' , st_post_address  = '" + st_adress + "' , st_email = '" + st_email + "' ,int_type_cus = " + int_type_cus + " , st_type_cus = '" + st_type_cus + "' where int_id = " + Session["id_Accont"].ToString() + " ");
                            Response.Write(@"<script>alert('บันทึกเรียบร้อย')</script>");
                            pn_edit_role.Visible = false;
                            gdv_Role_admin.Visible = true;
                            gdv_Role_admin.DataSource = Conncetions_db.Instance.Connection_command("SELECT [status] ,  [int_id], [st_user], [st_email], [st_type_cus] FROM [MD_Account] where st_user != 'suparat004' ");
                            gdv_Role_admin.DataBind();
                        }  
                       
                    }
                    catch (Exception ex)
                    {
                        Response.Write(@"<script>alert('บันทึกเรียบร้อย')</script>");
                        Response.Redirect("~/Page/List_book.aspx");
                    }
                }


            }


            else
            {
                Response.Write(@"<script>alert('กรุณากรอกข้อมูลให้ครบ')</script>");
            }
        }

        protected void gdv_Role_admin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdv_Role_admin.EditIndex = e.NewEditIndex;
            this.DataBind();
        }

        protected void gdv_Role_admin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gdv_Role_admin.EditIndex = e.RowIndex;
            this.DataBind();
        }

        protected void add_ServerClick(object sender, EventArgs e)
        {
            Session["add"] = 1;
            pn_edit_role.Visible = true;
            gdv_Role_admin.Visible = false;
            txt_login.Value = "";
            txt_password.Value = "";
            txt_Email.Value = "";
            txt_address.Value = "";
            txt_name.Value = "";
            ddl_role.SelectedIndex = 1;
        }

        protected void Expire_ServerClick(object sender, EventArgs e)
        {
            gdv_Role_admin.DataSource = Conncetions_db.Instance.Connection_command("SELECT [status] ,  [int_id], [st_user], [st_email], [st_type_cus] FROM [MD_Account] where dt_cus_expire_cus_day < getdate() ");
            gdv_Role_admin.DataBind();
        }

        protected void List_ServerClick(object sender, EventArgs e)
        {
            gdv_Role_admin.DataSource = Conncetions_db.Instance.Connection_command("SELECT [status] ,  [int_id], [st_user], [st_email], [st_type_cus] FROM [MD_Account] where st_user != 'suparat004' ");
            gdv_Role_admin.DataBind();
        }
    }
}