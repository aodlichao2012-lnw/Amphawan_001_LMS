using LMS_002.DbContext_db;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Admin
{
    public partial class return_detail : System.Web.UI.Page
    {
        StringBuilder stringBuilder = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Page.SetFocus(txt_barcode.ClientID);
            }
        }

        protected void sendto_lend_ServerClick(object sender, EventArgs e)
        {
           
            //lb_list_book.Text = "\n" + item["st_name_book"].ToString() + ": รหัสหนังสือ =  " + item["st_ISBN_ISSN"].ToString() + "\n";

        }

        protected void clear_list_ServerClick(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void return_ServerClick(object sender, EventArgs e)
        {
            string id_book = string.Empty;
            return_main.Visible = false;
            detail_return.Visible = true;
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkrows");
                var id = gvrow.Cells[4].Text;
                id_book = id.ToString();

                if (chk.Checked)
                {
                    var result = Conncetions_db.Instance.Connection_command(@"select * from [dbo].[MD_catralog_book] left join MD_statusbook on " +
                      "[dbo].[MD_catralog_book].int_cheeckin_out = MD_statusbook.self_id   where  st_ISBN_ISSN = '" + id_book + "' AND int_cheeckin_out = 1 ");
                    stringBuilder.AppendLine("<div class='card'>");
                    stringBuilder.AppendLine("<div class='card-header'>เลขเรียกหนังสือ</div>");
                    stringBuilder.AppendLine("<div class='card-body'>" + result.Rows[0]["st_callnumber"].ToString()+ "</div>");
                    stringBuilder.AppendLine("<div class='card-header'>ชื่อหนังสือ</div>");
                    stringBuilder.AppendLine("<div class='card-body'>" + result.Rows[0]["st_name_book"].ToString()+ "</div>");
                    stringBuilder.AppendLine("<div class='card-header'>ISBN -ISSN</div>");
                    stringBuilder.AppendLine("<div class='card-body'>" + result.Rows[0]["st_ISBN_ISSN"].ToString()+ "</div>");
                    stringBuilder.AppendLine("<div class='card-header'>รายละเอียด</div>");
                    stringBuilder.AppendLine("<div class='card-body'>" + result.Rows[0]["st_detail_book"].ToString()+ "</div>");
                    stringBuilder.AppendLine("<div class='card-header'>รูปหน้าปก</div>");
                    stringBuilder.AppendLine("<div class='card-body'><img src='" + result.Rows[0]["img_path"].ToString() + "' width='100' height='100' /> </div> ");
                    stringBuilder.AppendLine("<div class='card-header'>ผู้ยืม</div>");
                    stringBuilder.AppendLine("<div class='card-body'>" + result.Rows[0]["st_lend_name"].ToString()+ "</div>");
                    stringBuilder.AppendLine("<div class='card-header'>บาร์ โค้ด</div>");
                    stringBuilder.AppendLine("<div class='card-body'>" + result.Rows[0]["barcode"].ToString()+ "</div>");
                    stringBuilder.AppendLine("<div class='card-header'>วันที่ยืม</div>");
                    stringBuilder.AppendLine("<div class='card-body'>" + result.Rows[0]["dt_checkout_date"].ToString()+ "</div>");
                    stringBuilder.AppendLine("<div class='card-header'>ยืมถึงวันที่</div>");
                    stringBuilder.AppendLine("<div class='card-body'>" + result.Rows[0]["dt_checkin_due"].ToString()+ "</div>");
                    stringBuilder.AppendLine("</div>");
                    DateTime dt = DateTime.Now;
                    DateTime duedate = DateTime.Parse(result.Rows[0]["dt_checkin_due"].ToString());
                    //DateTime duedate = DateTime.ParseExact(result.Rows[0]["dt_checkin_due"].ToString(), "MM-dd-yyyy hh:mm:ss", new CultureInfo("en-En"));

                    System.Diagnostics.Debug.WriteLine($"now: {dt.Day} - {dt.Month} - {dt.Year}");
                    System.Diagnostics.Debug.WriteLine($"duedate : {duedate.Day} - {duedate.Month} - {duedate.Year}");

                    if (DateTime.Now > duedate)
                    {
                        stringBuilder.AppendLine("<p>เกินกำหนดคืนแล้ว</p>");
                        var duetotal =   dt.Subtract(duedate).Days / (365.25 / 12);


                    }
                    lb_list.InnerHtml += stringBuilder.ToString();
                }
            }
        }

        protected void txt_account_TextChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = Conncetions_db.Instance.Connection_command("select * from [dbo].[MD_catralog_book] left join MD_statusbook on " +
                      "[dbo].[MD_catralog_book].int_cheeckin_out = MD_statusbook.self_id   where  barcode = '" + txt_barcode.Text + "' AND int_cheeckin_out = 1 ");
            GridView1.DataBind();
        }

 

        protected void chkrows_CheckedChanged1(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkrows");
                if (chk.Checked)
                {
                    chk.Checked = true;
                }
                else if (!chk.Checked)
                {
                    chk.Checked = false;
                }
            }
        }

        protected void txt_barcode_TextChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = Conncetions_db.Instance.Connection_command("select * from [dbo].[MD_catralog_book] left join MD_statusbook on " +
                     "[dbo].[MD_catralog_book].int_cheeckin_out = MD_statusbook.self_id   where  barcode = '" + txt_barcode.Text + "' AND int_cheeckin_out = 1 ");
            GridView1.DataBind();
        }
    }
}