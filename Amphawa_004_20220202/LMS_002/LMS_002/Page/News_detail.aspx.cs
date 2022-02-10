using LMS_002.DbContext_db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Page
{
    public partial class News_detail : System.Web.UI.Page
    {
        string details = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["detail"] != null)
            {
                details = Request.QueryString["detail"].ToString();
            }

            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = Conncetions_db.Instance.Connection_command($@"SELECT [id_news]
                                                          ,[st_news]
                                                          ,[dt_news]
                                                          ,[count_view]
                                                          ,[st_topic_new]
                                                          ,[st_into_news]
                                                          ,[img_path]
                                                          ,[video_path] FROM [dbo].[MD_News] WHERE id_news = {details}");
                StringBuilder text = new StringBuilder();
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    text.Append($"<p> หัวข้อ : { dt.Rows[i]["st_topic_new"].ToString() }</p>");
                    text.Append($"<p> วันที่ : { dt.Rows[i]["dt_news"].ToString() }</p>");
                    text.Append($"<p> ข่าว : { dt.Rows[i]["st_into_news"].ToString() }</p>");
                    text.Append($"<p> รายละเอียดข่าว : { dt.Rows[i]["st_news"].ToString() }</p>");
                    text.Append($"<p> จำนวนครั้งที่ ดู  : { dt.Rows[i]["count_view"].ToString() }</p>");

                    //text.Append($"<a runat='server' id='text{ count }' href='News_detail.aspx?detail={ dt.Rows[i]["id_news"].ToString() }'> เปิดอ่าน  : </a>");
                    count += Convert.ToInt32(dt.Rows[i]["count_view"].ToString()) + 1;
                    dt = Conncetions_db.Instance.Connection_command("update  [dbo].[MD_News] set count_view = " + count + " where id_news = '" + details + "'");
                    detail.Text = text.ToString();
                }
            }
           
        }

        protected void sendto_lend_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Page/News_topic.aspx");
        }
    }
}