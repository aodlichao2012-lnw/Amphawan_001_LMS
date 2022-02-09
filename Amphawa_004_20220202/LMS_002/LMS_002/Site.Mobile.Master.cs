using LMS_002.DbContext_db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        string  profile ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (var cs = new Dbcon_wan())
            {
                if (Session["user"] == null)
                {
                    Session["user"] = "ผู้ใช้ภายนอก โปรด Login เพื่อเข้าสู่ระบบ";
                    lb_user.Text = Session["user"].ToString();
                    Session["role"] = 3;
                    menu_role.Visible = false;
                    menu_lend.Visible = false;
                    menu_throw.Visible = false;
                    menu_his.Visible = false;
                    menu_status.Visible = false;
                     logout_edit.Visible = false;
                    logout_login.Visible = false;
                    login_other_people.Visible = true;
                        import_book.Visible = false;
                }
                else if(Session["user"] != null)
                {
                    lb_user.Text = Session["user"].ToString();
                        if (Session["roleid"] != null)
                        {
                            profile = Session["roleid"].ToString();
                            Session["role"] = profile;

                            if (Session["role"].ToString() == "1")
                            {
                                menu_role.Visible = false;
                                menu_lend.Visible = true;
                                menu_throw.Visible = true;
                                menu_his.Visible = true;
                                menu_status.Visible = true;
                                logout_edit.Visible = true;
                              logout_login.Visible = true;
                             login_other_people.Visible = false;
                            lb_status.Text = "สถานะ โปรไฟล์ : เจ้าหน้าที่";
                                import_book.Visible = false;
                            }
                            else if (Session["role"].ToString() == "2")
                            {
                                menu_role.Visible = true;
                                menu_lend.Visible = true;
                                menu_throw.Visible = true;
                                menu_his.Visible = true;
                                menu_status.Visible = true;
                             logout_edit.Visible = true;
                              logout_login.Visible = true;
                              login_other_people.Visible = false;
                                import_book.Visible = true;
                            lb_status.Text = "สถานะ โปรไฟล์ : ผู้ดูแล";
                            }
                            else if (Session["role"].ToString() == "3")
                            {
                                menu_role.Visible = false;
                                menu_lend.Visible = false;
                                menu_throw.Visible = false;
                                menu_his.Visible = true;
                                menu_status.Visible = true;
                             logout_edit.Visible = true;
                              logout_login.Visible = true;
                             login_other_people.Visible = false;
                                import_book.Visible = false;
                               lb_status.Text = "สถานะ โปรไฟล์ : บุคคลทั่วไป";
                            }
                        }
                        else
                        {
                            Session["user"] = null;
                            lb_user.Text = null;
                            Session["role"] = 3;
                        Session["user"] = "ผู้ใช้ภายนอก โปรด Login เพื่อเข้าสู่ระบบ";
                            menu_role.Visible = false;
                            menu_lend.Visible = false;
                            menu_throw.Visible = false;
                            menu_his.Visible = false;
                            menu_status.Visible = false;
                         logout_edit.Visible = false;
                          logout_login.Visible = false;
                         login_other_people.Visible = true;
                            import_book.Visible = false;
                        }




                }
            }


        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {

        }

        protected void logout_login_ServerClick(object sender, EventArgs e)
        {
            if (Session["roleid"] != null)
            {
                Session["user"] = null;
                lb_user.Text = "ผู้ใช้ภายนอก โปรดLogin เพื่อเข้าสู่ระบบ";
                Session["role"] = null;
                Session["roleid"] = null;
                menu_role.Visible = false;
                menu_lend.Visible = false;
                menu_throw.Visible = false;
                menu_his.Visible = false;
                menu_status.Visible = false;
                 logout_edit.Visible = false;
                   logout_login.Visible = false;
                    import_book.Visible = false;
                 login_other_people.Visible = true;
                  Response.Redirect(@"~/Page/Login.aspx");

            }
            else
            {
                Response.Redirect(@"~/Page/Login.aspx");
            }
        }

        protected void logout_edit_ServerClick(object sender, EventArgs e)
        {
            if (Session["roleid"] != null)
            {
                 Response.Redirect(@"~/Page/Edit_profile.aspx?id_user="+Session["roleid"].ToString()+"");
            
            }

         }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {

        }

        protected void login_ServerClick(object sender, EventArgs e)
        {
              Response.Redirect(@"~/Page/Login.aspx");
        }

        protected void login_other_people_ServerClick(object sender, EventArgs e)
        {
              Response.Redirect(@"~/Page/Login.aspx");
        }

        protected void FeaturedContent_Init(object sender, EventArgs e)
        {
           
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/Mobile.Master";
        }

    }
}
