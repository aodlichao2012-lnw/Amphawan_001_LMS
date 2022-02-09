using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Page/Login.aspx");
        }

        protected void logout_login_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Page/Login.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            if (Session["roleid"] != null)
            {
                Session["user"] = null;
                Session["roleid"] = null;
                Response.Redirect(@"~/Page/Login.aspx");

            }
            else
            {
                Session["user"] = null;
                Session["roleid"] = null;
                Response.Redirect(@"~/Page/Login.aspx");
            }
        }

        protected void lend_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Admin/Lean_book.aspx");
        }

        protected void return2_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Admin/return_detail.aspx");
        }
    }
}