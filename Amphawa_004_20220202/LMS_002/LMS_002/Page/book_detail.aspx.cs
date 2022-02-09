using LMS_002.DbContext_db;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Page
{
    public partial class book_detail : System.Web.UI.Page
    {
        string issn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(ConfigurationManager.AppSettings["Language"]);
            if (Request.QueryString["issn"] != null)
            {
                issn = Request.QueryString["issn"].ToString();
                DataTable dt = new DataTable();
                dt = Conncetions_db.Instance.Connection_command("select *   FROM [dbo].[MD_catralog_book] where st_ISBN_ISSN = '" + issn + "'");
                StringBuilder text = new StringBuilder();
                if (dt.Rows.Count > 0)
                {
                    text.Append($"<p> { Resource.Resource.name_book } : { dt.Rows[0]["st_name_book"].ToString() }</p>");
                    text.Append($"<p> ISBN : { dt.Rows[0]["st_ISBN_ISSN"].ToString() }</p>");
                    text.Append($"<p> {Resource.Resource.date_import} : { dt.Rows[0]["dt_DATE_modify"].ToString() }</p>");
                    text.Append($"<p> {Resource.Resource.type_book} : { dt.Rows[0]["st_type_book_name"].ToString() }</p>");
                    text.Append($"<p> {Resource.Resource.img_book} : <img src='{ dt.Rows[0]["img_path"].ToString() }' width='100' height='100' /></p>");
                    if(dt.Rows[0]["video_path"].ToString() != "")
                    {
                        text.Append($"<p> {Resource.Resource.video} :  <video width='320' height='240' controls controlsList='nodownload'>   <source src='{ dt.Rows[0]["video_path"].ToString() }#t=5,10' type='video/mp4' >  Your browser does not support the video tag. </ video ></p>");

                    }
                    if(dt.Rows[0]["sound_part"].ToString() != "")
                    {
                        text.Append($"<p> {Resource.Resource.sound_part} :  <audio controls controlsList='nodownload'> <source src='{ dt.Rows[0]["sound_part"].ToString() }#t=5,10' type ='audio/mp3'> Your browser does not support the audio element. </ audio > /></p>");
                    }
                    if(dt.Rows[0]["ebook_path"].ToString() != "")
                    {
                        text.Append($"<p> E-book : <embed src='{ dt.Rows[0]["ebook_path"].ToString() }' width='800px' height='2100px' /> </p>");
                    }
                    text.Append($"<p> {Resource.Resource.status_book} : { dt.Rows[0]["st_cheeckin_out"].ToString() }</p>");
                    text.Append($"<p> {Resource.Resource.count_print} : { dt.Rows[0]["count_print"].ToString() }</p>");
                    text.Append($"<p> {Resource.Resource.place_print} : { dt.Rows[0]["plate_print"].ToString() }</p>");
                    text.Append($"<p> {Resource.Resource.company_print} : { dt.Rows[0]["company_print"].ToString() }</p>");
                    text.Append($"<p> {Resource.Resource.detail_book} : { dt.Rows[0]["st_detail_book"].ToString() }</p>");
                    text.Append($"<p> {Resource.Resource.language} : { dt.Rows[0]["st_lang"].ToString() }</p>");
                    text.Append($"<p> {Resource.Resource.count_view}  : { dt.Rows[0]["int_count_view_book"].ToString() }</p>");

                    detail.Text = text.ToString();
                    int count = Convert.ToInt32(dt.Rows[0]["int_count_view_book"].ToString()) + 1;

                    dt = Conncetions_db.Instance.Connection_command("update  [dbo].[MD_catralog_book] set int_count_view_book = " + count + " where st_ISBN_ISSN = '" + issn + "'");
                }
            }
        }

        protected void sendto_lend_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Page/List_book.aspx");
        }
    }
}