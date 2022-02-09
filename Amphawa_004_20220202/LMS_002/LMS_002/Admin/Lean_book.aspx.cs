using LMS_002.DbContext_db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Admin
{

    public partial class Lean_book : System.Web.UI.Page
    {
        static int count = 0;
        DataTable dt = new DataTable();
        string profile = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            this.Page.SetFocus(txt_keyword.ClientID);
            if (!Page.IsPostBack)
            {
                if (Session["user"] != null)
                {
                   
                }
            }

        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;

            }
            catch
            {

            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {

                    GridView1.DataSource = Conncetions_db.Instance.Connection_command("select * from [dbo].[MD_catralog_book] left join MD_statusbook on " +
                                       "[dbo].[MD_catralog_book].int_cheeckin_out = MD_statusbook.self_id   where  st_process_name_user = '" + profile + "' AND int_cheeckin_out = 3 ");
                    GridView1.DataBind();
            }
            catch
            {

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void searchCatalog_ServerClick(object sender, EventArgs e)
        {
            string account_cus = ddl_account.Text;
            var id = 0;
            DataTable oldcount = new DataTable();
            foreach (GridViewRow gvrow in GridView2.Rows)
            {
                id = Convert.ToInt32(gvrow.Cells[1].Text);
                try
                {
                    profile = Session["user"].ToString();
                    string lend_date2 = Convert.ToDateTime(lend_date.Value).ToString("MM-dd-yyyy", new CultureInfo("en-EN"));
                    string due_date2 =  Convert.ToDateTime(due_date.Value).ToString("MM-dd-yyyy", new CultureInfo("en-EN"));
                    var update = Conncetions_db.Instance.Connection_command(@"UPDATE [dbo].[MD_catralog_book] SET  [int_cheeckin_out] = 1 ,[st_cheeckin_out] = 'ถูกยืม' , [dt_checkout_date] = '" + lend_date2 + "', " +
                        " [dt_checkin_due] = '" + due_date2 + "' , st_process_name_user = '" + profile + "' , st_lend_name = '" + account_cus + "'  WHERE int_id_catalog_book = " + id + "");
                    string min = Convert.ToDateTime(lend_date.Value).ToString("MM-dd-yyyy", new CultureInfo("en-EN"));
                    string max = Convert.ToDateTime(due_date.Value).ToString("MM-dd-yyyy", new CultureInfo("en-EN"));
                    var updates = Conncetions_db.Instance.Connection_command(@"UPDATE [dbo].[MD_catralog_book] SET  [int_cheeckin_out] = 1 ,[st_cheeckin_out] = 'ถูกยืม' , [dt_checkout_date] = '" + min + "', " +
                        " [dt_checkin_date] = '" + max + "' , st_process_name_user = '" + profile + "' , st_lend_name = '" + account_cus + "'  WHERE int_id_catalog_book = " + id + "");
                    oldcount = Conncetions_db.Instance.Connection_command(@"select SUM(Convert( int , st_count )) as counts from [dbo].[MD_Account] inner join [dbo].[MD_catralog_book] on [dbo].[MD_Account].
                    st_user = [dbo].[MD_catralog_book].st_lend_name where st_lend_name = '" + account_cus + "'");
                    var update_cus = Conncetions_db.Instance.Connection_command(@"UPDATE [dbo].[MD_Account] SET [st_count] = " + count + ", [decimal_cus_from_least] = 0.00  WHERE st_user = " +
                        " '" + account_cus + "'");


                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            //int sumcount = count;
            //if (oldcount != null)
            //{
            //    sumcount = sumcount + Convert.ToInt32(oldcount.Rows[0]["counts"].ToString());
            //}

            Conncetions_db.Instance.Connection_command(@"UPDATE [dbo].[MD_Account] SET [st_count] = " + count + " from [dbo].[MD_Account]   inner join [dbo].[MD_catralog_book] on [dbo].[MD_Account].st_user = " +
                "[dbo].[MD_catralog_book].st_lend_name where st_lend_name = '" + account_cus + "'");
            count = 0;
            count_book.Value = count.ToString();
            GridView2.DataSource = null;
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView2.DataBind();
            Response.Write(@"<script>window.open('../Report_pdf/slip_lend_pdf.aspx?user=" + profile + "&cus=" + account_cus + "' , '_blank');</script>");
        }

    

        protected void txt_keyword_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string select = $@"SELECT top 1 int_id_catalog_book , st_name_book ,  st_ISBN_ISSN  , img_path , st_detail_book , dt_DATE_modify , st_cheeckin_out ,  st_type_book_name
                            , MD_statusbook.status_book as status_book 
                            FROM MD_catralog_book
                            LEFT JOIN MD_statusbook ON MD_catralog_book.int_cheeckin_out = MD_statusbook.self_id
                            INNER JOIN dbo.MD_type_book ON MD_catralog_book.st_type_book = MD_type_book.self_id  
                                                                   WHERE barcode LIKE  '{txt_keyword.Text}' AND MD_statusbook.self_id = 0
                                                                 ";


                dt = Conncetions_db.Instance.Connection_command(@"" + select + "");
                if (dt.Rows == null)
                {
                    Response.Write(@"<script>alert('ไม่มีหนังสือ อยู่ในระบบ')</script>");
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btn_cancle_Click(object sender, EventArgs e)
        {
            
            var id = "";
            foreach (GridViewRow gvrow in GridView2.Rows)
            {
                id += Convert.ToInt32(gvrow.Cells[1].Text);
                var update = Conncetions_db.Instance.Connection_command(@"UPDATE [dbo].[MD_catralog_book] SET  [int_cheeckin_out] = 0 ,[st_cheeckin_out] = 'พร้อมยืม' ,
                    st_lend_name = ''  WHERE int_id_catalog_book = " + id + "");
                GridView2.DataBind();
                ld_count.Text = "0";
                count = 0;
                count_book.Value = count.ToString();
                list_acc.Visible = false;
            }
        }

        protected void chkrows_CheckedChanged1(object sender, EventArgs e)
        {
    
        }

        protected void chkrows_CheckedChanged(object sender, EventArgs e)
        {
            string account_cus = ddl_account.Text;
            var id = "";
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)sender;
                if (chk.Checked)
                {
                    id += Convert.ToInt32(gvrow.Cells[1].Text);
                    count += 1;
                    count_book.Value = count.ToString();
                    var update = Conncetions_db.Instance.Connection_command(@"UPDATE [dbo].[MD_catralog_book] SET  [int_cheeckin_out] = 3 ,[st_cheeckin_out] = 'เตรียมพร้อมเพื่อยืม' , 
                    st_lend_name = '" + account_cus + "'  WHERE int_id_catalog_book = " + id + "");

                    var result = Conncetions_db.Instance.Connection_command("select count(*) as total from [dbo].[MD_catralog_book] where  int_cheeckin_out = 3 AND st_lend_name = '" + account_cus + "' ");
                    ld_count.Text = result.Rows[0]["total"].ToString();
                    chk.Checked = false;
                }
                else
                {
                    count -= 1;
                    count_book.Value = count.ToString();
                }
            }
            GridView2.DataSource = Conncetions_db.Instance.Connection_command(@"select * , MD_type_book.Type_book as Type_book from [dbo].[MD_catralog_book] 
                            LEFT JOIN MD_statusbook ON MD_catralog_book.int_cheeckin_out = MD_statusbook.self_id
                            INNER JOIN dbo.MD_type_book ON MD_catralog_book.st_type_book = MD_type_book.self_id where st_lend_name = '" + account_cus + "'  AND  [int_cheeckin_out] = 3");
            GridView2.DataBind();
        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddl_account_TextChanged(object sender, EventArgs e)
        {
            list_acc.Visible = true;
            dt = Conncetions_db.Instance.Connection_command($@"select st_user from [dbo].[MD_Account] where st_user LIKE '%{ddl_account.Text}%'");
            for(int i = 0; i < dt.Rows.Count; i ++)
            {
                list_acc.Items.Add(dt.Rows[i]["st_user"].ToString());
            }
           
        }

        protected void list_acc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_account.Text = list_acc.SelectedItem.Text;
            list_acc.Visible = false;
        }
    }
}