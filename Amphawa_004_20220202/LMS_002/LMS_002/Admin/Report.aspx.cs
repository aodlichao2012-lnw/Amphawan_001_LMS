
﻿using Aspose.Pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using LMS_002.DbContext_db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Admin
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = Conncetions_db.Instance.Connection_command(@" select COUNT(st_name_book) as st_name_book from dbo.MD_catralog_book");
                DataTable dt2 = Conncetions_db.Instance.Connection_command(@"select COUNT(int_id_catalog_book) as int_id_catalog_book
                                    from dbo.MD_catralog_book");
                DataTable dt3 = Conncetions_db.Instance.Connection_command(@"select SUM(int_cheeckin_out) as int_cheeckin_out  from dbo.MD_catralog_book ");
                DataTable dt4 = Conncetions_db.Instance.Connection_command(@"select count(type_book) as type_book from MD_type_book");
                DataTable dt5 = Conncetions_db.Instance.Connection_command(@"select top 10 st_name_book
                                    from dbo.MD_catralog_book where int_cheeckin_out = 1");
                total_namebook.InnerText = dt.Rows[0]["st_name_book"].ToString();
                total_book.InnerText = dt2.Rows[0]["int_id_catalog_book"].ToString();
                total_lend.InnerText = dt3.Rows[0]["int_cheeckin_out"].ToString();
                total_type.InnerText = dt4.Rows[0]["type_book"].ToString();
                total_type2.InnerText = dt4.Rows[0]["type_book"].ToString();

                lb_top_lend.InnerText = dt5.Rows[0]["st_name_book"].ToString();
            }

        }

        protected void submit_ServerClick(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(" สรุปรายการสถิติการใช้ทรัพยากรสารสนเทศ ");
            stringBuilder.AppendLine("ชื่อเรื่องทั้งหมด");
            stringBuilder.AppendLine(total_namebook.InnerText);
            stringBuilder.AppendLine("รายการตัวเล่มทั้งหมด");
            stringBuilder.AppendLine(total_book.InnerText);
            stringBuilder.AppendLine("รายการยืมตัวเล่มทั้งหมด");
            stringBuilder.AppendLine(total_lend.InnerText);
            stringBuilder.AppendLine("รายการชื่อเรื่องแบ่งตามประเภทวัสดุ/มีเดีย");
            stringBuilder.AppendLine(total_type.InnerText);
            stringBuilder.AppendLine("รายการตัวเล่มทั้งหมดแบ่งตามประเภททรัพยากรสารสนเทศ");
            stringBuilder.AppendLine(total_type2.InnerText);
            stringBuilder.AppendLine("ชื่อเรื่อง 10 ลำดับแรกที่ถูกยืมมากที่สุด");
            stringBuilder.AppendLine(lb_top_lend.InnerText);
            //return res;
            string path = @"C:\Report_pdf\Report" + DateTime.Now.ToOADate().ToString() + ".txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
               file.WriteLine(stringBuilder.ToString());// "sb" is the StringBuilder
            }
            Response.Write($@"<script>alert('คุณได้เก็บ Report ไว้ที่ C:\Report_pdf แล้ว ')</script>");
            }
    }
}