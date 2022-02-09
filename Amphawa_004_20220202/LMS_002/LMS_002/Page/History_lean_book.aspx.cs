using LMS_002.DbContext_db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Page
{
    public partial class History_lean_book : System.Web.UI.Page
    {
        string profile = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null)
            {
                profile = Session["user"].ToString();
                GridView1.DataSource = Conncetions_db.Instance.Connection_command("select * from [dbo].[MD_catralog_book] left join MD_statusbook on" +
               " [dbo].[MD_catralog_book].int_cheeckin_out = MD_statusbook.self_id  where  st_process_name_user = '" + profile + "' ");
                GridView1.DataBind();
            }
        }

        protected void searchCatalog_ServerClick(object sender, EventArgs e)
        {
            string min = min_date.Value.Equals("") ? DateTime.Now.ToString("yyyy/MM/dd") : min_date.Value;
            string max = max_date.Value.Equals("") ? DateTime.Now.ToString("yyyy/MM/dd") : max_date.Value;
            GridView1.DataSource = Conncetions_db.Instance.Connection_command("select * from [dbo].[MD_catralog_book] inner join MD_statusbook on [dbo]." +
                "[MD_catralog_book].int_cheeckin_out = MD_statusbook.self_id where st_process_name_user = '" + profile + "' AND  st_type_book = 0  AND st_name_book LIKE " +
                "'%" + txt_name_book.Value + "%' AND st_ISBN_ISSN LIKE  '%" + txt_iss_num.Value + "%' OR  dt_checkin_date BETWEEN " +
                "" + min + " AND " + max + "  order by st_ISBN_ISSN ASC");
            GridView1.DataBind();
        }

        protected void clear_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Page/History_lean_book.aspx");
        }

        protected void clear_ServerClick1(object sender, EventArgs e)
        {

            Response.Redirect(@"~/Page/History_lean_book.aspx");
        }
    }
}