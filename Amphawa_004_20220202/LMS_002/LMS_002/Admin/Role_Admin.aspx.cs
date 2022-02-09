using LMS_002.DbContext_db;
using LMS_002.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Admin
{
    public partial class Role_Admin : System.Web.UI.Page
    {
        MD_Account md_account = new MD_Account();
        string user_ = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                gdv_Role_admin.DataSource = Conncetions_db.Instance.Connection_command("SELECT [int_id], [st_user], [st_email], [st_type_cus] FROM [MD_Account] where st_user != 'suparat004' ");
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
                using (var db_ = new Dbcon_wan())
                {
                    md_account = db_.tb_account.Where(a => a.int_id == id).FirstOrDefault();
                    Session["id_Accont"] = md_account.int_id;
                    txt_login.Value = md_account.st_user;
                    txt_password.Value = md_account.st_password;
                    txt_Email.Value = md_account.st_email;
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
                        Response.Redirect("~/Page/Role_Admin.aspx");

                    }
                }
                catch
                {
                    Response.Write(@"<script>alert('ลบเรียบร้อย')</script>");
                    Response.Redirect("~/Page/Role_Admin.aspx");
                }

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
                        var result = db.tb_account.Any(s => s.st_user == txt_login.Value);
                        if (result)
                        {
                            Response.Write(@"<script>alert('มีผู้ใช้อยู่แล้ว')</script>");
                        }

                        string user = txt_login.Value;
                        string st_password = txt_password.Value;
                        string st_email = txt_Email.Value;
                        string st_type_cus = ddl_role.SelectedItem.Text;
                        if (Session["user"].ToString() == user)
                        {
                            Session["user"] = user;
                        }

                        int int_type_cus = ddl_role.SelectedValue.ToString().Equals("") ? 3 : Convert.ToInt32(ddl_role.SelectedValue.ToString());
                        var cs = Conncetions_db.Instance.Connection_command(@" UPDATE [dbo].[MD_Account] SET st_user = '" + user + "' , " +
                              "st_password = '" + st_password + "' , st_email = '" + st_email + "' ,int_type_cus = " + int_type_cus + " , st_type_cus = '" + st_type_cus + "' where int_id = " + Session["id_Accont"].ToString() + " ");
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
    }
}