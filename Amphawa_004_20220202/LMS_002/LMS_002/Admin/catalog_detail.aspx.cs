using LMS_002.DbContext_db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Admin
{
    public partial class catalog_detail : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string isbn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["ISBN"].ToString() != "")
            {
                isbn = Request.QueryString["ISBN"].ToString();
            }
            if(!Page.IsPostBack)
            {
                dt = Conncetions_db.Instance.Connection_command(@"SELECT st_name_book ,  st_ISBN_ISSN  , img_path , st_type_book_name ,  st_detail_book , st_type_book_name , dt_DATE_modify , st_cheeckin_out , 
                            MD_type_book.Type_book , st_callnumber 
                            FROM MD_catralog_book
                            LEFT JOIN MD_type_book ON MD_catralog_book.int_cheeckin_out = MD_type_book.self_id
                            LEFT JOIN dbo.MD_statusbook ON MD_catralog_book.st_type_book = MD_statusbook.self_id  
                            where  int_cheeckin_out != 3  AND  st_ISBN_ISSN = '" + isbn+"'");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
           
        }
        protected void btn_check__CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                if(chk.Checked)
                {
                    chk.Checked = true;
                }
                else if(!chk.Checked)
                {
                    chk.Checked = false;
                }
            }
        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            string id_book = String.Empty;
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                if (chk != null & chk.Checked)
                {
                    var id = gvrow.Cells[4].Text;
                    id_book = id.ToString();

                    dt = Conncetions_db.Instance.Connection_command(@"select int_id_catalog_book from MD_catralog_book where st_ISBN_ISSN ='" + id_book + "'" +
                        " AND int_cheeckin_out != 1 ");
                    string id_pk_book = dt.Rows[0]["int_id_catalog_book"].ToString();
                    try
                    {
                        var update = Conncetions_db.Instance.Connection_command(@"DELETE [dbo].[MD_catralog_book]  WHERE st_ISBN_ISSN = '" + id + "' AND int_id_catalog_book = " + id_pk_book + "  " +
                            "");
                        dt = Conncetions_db.Instance.Connection_command(@"SELECT st_name_book , st_type_book_name ,  st_ISBN_ISSN  , img_path , st_detail_book , dt_DATE_modify , st_cheeckin_out , 
                            MD_type_book.Type_book , st_callnumber 
                            FROM MD_catralog_book
                            LEFT JOIN MD_type_book ON MD_catralog_book.int_cheeckin_out = MD_type_book.self_id
                            LEFT JOIN dbo.MD_statusbook ON MD_catralog_book.st_type_book = MD_statusbook.self_id  
                            where  int_cheeckin_out != 3 ");
                        GridView1.DataSource = dt;
                        GridView1.DataBind();


                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}