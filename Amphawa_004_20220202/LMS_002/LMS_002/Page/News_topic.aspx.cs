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
    public partial class News_topic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Conncetions_db.Instance.Connection_command("select *   FROM [dbo].[MD_catralog_book] ");
            StringBuilder text = new StringBuilder();
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                text.Append($"<p> ชื่อหนังสือ : { dt.Rows[i]["st_name_book"].ToString() }</p>");
                text.Append($"<p> ISSN : { dt.Rows[i]["st_ISBN_ISSN"].ToString() }</p>");
                text.Append($"<p> วันที่นำเข้า : { dt.Rows[i]["dt_DATE_modify"].ToString() }</p>");
                text.Append($"<p> ประเภทหนังสือ : { dt.Rows[i]["st_type_book_name"].ToString() }</p>");
                text.Append($"<p> รูป : <img src='{ dt.Rows[i]["st_name_book"].ToString() }' width='100' height='100' /></p>");
                text.Append($"<p> สถานะหนังสือ : { dt.Rows[i]["st_cheeckin_out"].ToString() }</p>");
                text.Append($"<p> จำนวนที่พิมพ์ : { dt.Rows[i]["count_print"].ToString() }</p>");
                text.Append($"<p> สถานที่พิมพ์ : { dt.Rows[i]["plate_print"].ToString() }</p>");
                text.Append($"<p> บริษัทที่พิมพ์ : { dt.Rows[i]["company_print"].ToString() }</p>");
                text.Append($"<p> รายละเอียดหนังสือ : { dt.Rows[i]["st_detail_book"].ToString() }</p>");
                text.Append($"<p> ภาษา : { dt.Rows[i]["st_lang"].ToString() }</p>");
                text.Append($"<p> จำนวนครั้งที่ ดู  : { dt.Rows[i]["int_count_view_book"].ToString() }</p>");

                text.Append($"<a runat='server' id='text{ count }' href='News_detail.aspx?detail={ dt.Rows[i]["int_id_catalog_book"].ToString() }'> เปิดอ่าน  : </a>");
                count += Convert.ToInt32(dt.Rows[i]["int_count_view_book"].ToString()) + 1;

                detail.Text = text.ToString();
            }

        }



        protected void sendto_lend_ServerClick(object sender, EventArgs e)
        {

        }
    }
}