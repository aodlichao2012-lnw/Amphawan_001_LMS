using LMS_002.DbContext_db;
using LMS_002.Models;
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
    public partial class Catalog_module : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string sql = "";
        string profile = "";
        string count_book = "";
        string img_book = "";
        string id_book = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt = Conncetions_db.Instance.Connection_command(@"SELECT st_name_book ,  st_ISBN_ISSN , st_type_book_name , img_path , st_detail_book , dt_DATE_modify , st_cheeckin_out ,  MD_type_book.Type_book  , COUNT(st_ISBN_ISSN) as count_
                            FROM MD_catralog_book
                            LEFT JOIN MD_type_book ON MD_catralog_book.int_cheeckin_out = MD_type_book.self_id
                            LEFT JOIN dbo.MD_statusbook ON MD_catralog_book.st_type_book = MD_statusbook.self_id  
                            where  int_cheeckin_out != 3 group by [st_ISBN_ISSN], img_path, st_detail_book, dt_DATE_modify, st_cheeckin_out  , st_name_book , st_type_book_name ,  MD_type_book.Type_book");
                GridView1.DataSource = dt;
                GridView1.DataBind();

                ddl_dictionnary.DataSource = Conncetions_db.Instance.Connection_command("select * from [dbo].[MD_Dictionary]");
                ddl_dictionnary.DataValueField = "int_id_type_Dictionary";
                ddl_dictionnary.DataTextField = "st_type_Dictionary";
                ddl_dictionnary.SelectedIndex = 1;
                ddl_dictionnary.DataBind();
            }

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

        //เลือกทั้งหมด
        protected void seleclall_ServerClick(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                chk.Checked = true;
            }

        }

        protected void unselect1_ServerClick(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                chk.Checked = false;
            }
        }

        protected void list_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Admin/Catalog_module.aspx");
        }

        protected void add_book_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~/Admin/Add_book_Admin.aspx");
        }

        protected void doSearch_ServerClick(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Dbcon_wan())
                {

                    string select = $@"SELECT st_name_book ,  st_ISBN_ISSN  , img_path , st_detail_book , st_type_book_name , dt_DATE_modify , st_cheeckin_out ,  MD_type_book.Type_book  , COUNT(st_ISBN_ISSN) as count_
                            FROM MD_catralog_book
                            LEFT JOIN MD_type_book ON MD_catralog_book.int_cheeckin_out = MD_type_book.self_id
                            LEFT JOIN dbo.MD_statusbook ON MD_catralog_book.st_type_book = MD_statusbook.self_id  
                                                                   WHERE {Types.Value} LIKE 
                                                                 ";

                    GridView1.DataSourceID = null;
                    List<MD_catralog_book> cs = new List<MD_catralog_book>();
                    if (Types.Value != "")
                    {
                        if (keywords.Value != "")
                        {
                            switch (Types.Value)
                            {
                                case "st_name_book":
                                    select += $" '%{ keywords.Value }%' ";

                                    break;
                                case "st_ISBN_ISSN":
                                    select += $" '%{ keywords.Value }%' ";
                                    break;
                                case "st_type_book_name":
                                    select += $" '%{ keywords.Value }%' ";
                                    break;
                                case "st_author":
                                    select += $" '%{ keywords.Value }%' ";
                                    break;
                                case "barcode":
                                    select += $" '%{ keywords.Value }%' ";
                                    break;
                                case "count_print":
                                    select += $" '%{ keywords.Value }%' ";
                                    break;
                            }
                            dt = Conncetions_db.Instance.Connection_command(@"" + select + $" AND  int_cheeckin_out != 3 AND int_type_Dictionary = {ddl_dictionnary.SelectedValue}" +
                                " group by [st_ISBN_ISSN] , img_path , st_detail_book , dt_DATE_modify , st_cheeckin_out , st_name_book , st_type_book_name  ,  MD_type_book.Type_book");
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            

                        }
                        else
                        {
                            dt = Conncetions_db.Instance.Connection_command($@"SELECT st_name_book , st_type_book_name ,  st_ISBN_ISSN  , img_path , st_detail_book , dt_DATE_modify , st_cheeckin_out ,  MD_type_book.Type_book  , COUNT(st_ISBN_ISSN) as count_
                            FROM MD_catralog_book
                            LEFT JOIN MD_type_book ON MD_catralog_book.int_cheeckin_out = MD_type_book.self_id
                            LEFT JOIN dbo.MD_statusbook ON MD_catralog_book.st_type_book = MD_statusbook.self_id  
                            where  int_cheeckin_out != 3 AND int_type_Dictionary = {ddl_dictionnary.SelectedValue} group by [st_ISBN_ISSN], img_path, st_detail_book, dt_DATE_modify, st_cheeckin_out  , st_name_book  ,  MD_type_book.Type_book , st_type_book_name");
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }


                    }
                }
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                using (var db = new Dbcon_wan())
                {

                    CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                    if (chk != null & chk.Checked)
                    {
                        var id = gvrow.Cells[4].Text;
                        id_book = id.ToString();

                        dt = Conncetions_db.Instance.Connection_command(@"select int_id_catalog_book from MD_catralog_book where " + Types.Value + " LIKE '%" + keywords.Value + "%' AND  st_ISBN_ISSN ='" + id_book + "'" +
                            "  ");
                        string id_pk_book = dt.Rows[0]["int_id_catalog_book"].ToString();
                        try
                        {
                            var update = Conncetions_db.Instance.Connection_command(@"DELETE [dbo].[MD_catralog_book]  WHERE st_ISBN_ISSN = '" + id + "' AND int_id_catalog_book = " + id_pk_book + "  " +
                                "");
                            GridView1.DataBind();

                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }

           

                    }
                }
            }
            Response.Redirect(@"~/Admin/Catalog_module.aspx");

        }

        protected void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("checkbox");
                if (chk.Checked)
                {
                    chk.Checked = true;
                }
                else if(!chk.Checked)
                {
                    chk.Checked = false;
                }
            }
        }

        protected void btn_list__Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;

            string pk = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            Response.Write(@"<script> window.open('catalog_detail.aspx?ISBN="+ pk + "' , '_blank' );</script>");
        }

        protected void btn_list_edit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;

            string pk = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
            Response.Write(@"<script> window.open('Add_book_Admin.aspx?ISBN=" + pk + "' , '_blank' );</script>");
        }
    }
}