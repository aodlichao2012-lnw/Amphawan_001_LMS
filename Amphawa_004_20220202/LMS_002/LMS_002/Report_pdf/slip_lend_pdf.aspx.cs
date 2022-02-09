using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Report_pdf
{
    public partial class slip_lend_pdf : System.Web.UI.Page
    {
        string username = "";
        string cus_account = "";
        string id_iss = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {

            }
            if(Request.QueryString["user"] != null)
            {
                username = Request.QueryString["user"].ToString();
            }
            if(Request.QueryString["cus"] != null)
            {
                cus_account = Request.QueryString["cus"].ToString();
            } 
            if(Request.QueryString["id_iss"] != null)
            {
                id_iss = Request.QueryString["id_iss"].ToString();
            }
            SqlDataSource1.SelectCommand = @"SELECT * FROM[dbo].[MD_catralog_book] left join dbo.MD_Account on dbo.MD_catralog_book.st_process_name_user = dbo.MD_Account.st_user where dbo.MD_catralog_book.st_lend_name = '" + cus_account + "'";
            SqlDataSource1.DataBind();        
            SqlDataSource2.SelectCommand = @"SELECT * FROM[dbo].[MD_catralog_book] left join dbo.MD_Account on dbo.MD_catralog_book.st_process_name_user = dbo.MD_Account.st_user where dbo.MD_catralog_book.st_lend_name = '" + cus_account + "' ";
            SqlDataSource2.DataBind();
        }
    }
}