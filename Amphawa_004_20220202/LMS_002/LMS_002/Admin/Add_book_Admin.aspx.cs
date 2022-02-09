using LMS_002.DbContext_db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LMS_002.Admin
{
    public partial class Add_book_Admin : System.Web.UI.Page
    {
        string isbn = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["ISBN"] != null)
            {
                isbn = Request.QueryString["ISBN"].ToString();
                Edit(isbn);
            }
            if (!Page.IsPostBack)
            {
                ddl_dictionnary.DataSource = Conncetions_db.Instance.Connection_command("select * from [dbo].[MD_Dictionary]");
                ddl_dictionnary.DataValueField = "int_id_type_Dictionary";
                ddl_dictionnary.DataTextField = "st_type_Dictionary";
                ddl_dictionnary.SelectedIndex = 1;
                ddl_dictionnary.DataBind();
            }

        }

        private void Edit(string isbn)
        {
            DataTable dt = Conncetions_db.Instance.Connection_command(@"SELECT * FROM MD_catralog_book WHERE st_ISBN_ISSN = '"+isbn+"'");
            if(dt.Rows.Count > 0)
            {
                txt_bar_code.Value = "";
                txt_author.Value = "";
                txt_bar_code.Value = "";
                txt_book_name.Value = "";
                txt_iss_num.Value = "";
                count_print.Value = "";
                plate_print.Value = "";
                company_print.Value = "";
                year_print.Value = "";
                call_number.Value = "";
                detail_book.Value = "";
                count_book.Value = "";
            }
        }

        protected void chk_book_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void searchCatalog_ServerClick(object sender, EventArgs e)
        {
            int count = int.Parse(count_book.Value);
            string int_types = Types.Value.Split(' ')[0];
            string st_types = Types.Value.Split(' ')[1];
            string pathTopic = "";
            string pathEbook = "";
            string pathVideo = "";
            string pathsound = "";
            System.Diagnostics.Debug.WriteLine("total books: " + count);

            for (int i = 0; i < count; i++)
            {
                switch (Types.SelectedIndex)
                {
                    case 0:
                        f_book.SaveAs(pathFile_.instance_.pathas(@"~\Content\Doc_all_type\topic\", f_book.FileName));
                        pathTopic = @"..\Doc_all_type\topic\"+f_book.FileName;
                        break;
                    case 1:
                        f_book.SaveAs(pathFile_.instance_.pathas(@"~\Content\Doc_all_type\topic\", f_book.FileName));
                        f_ebook.SaveAs(pathFile_.instance_.pathas(@"~\Content\Doc_all_type\ebook\", f_ebook.FileName));
                        pathTopic = @"..\Content\Doc_all_type\topic\" + f_book.FileName;
                        pathEbook = @"..\Content\Doc_all_type\ebook\" + f_book.FileName;
                        break;
                    case 3:
                        f_video.SaveAs(pathFile_.instance_.pathas(@"~\Content\Doc_all_type\video\", f_video.FileName));
                        f_book.SaveAs(pathFile_.instance_.pathas(@"~\Content\Doc_all_type\topic\", f_book.FileName));
                        pathTopic = @"..\Content\Doc_all_type\topic\" + f_book.FileName;
                        pathVideo = @"..\Content\Doc_all_type\video\" + f_video.FileName;
                        break;  
                    case 2:
                        f_sound.SaveAs(pathFile_.instance_.pathas(@"~\Content\Doc_all_type\Sound\", f_sound.FileName));
                        f_book.SaveAs(pathFile_.instance_.pathas(@"~\Content\Doc_all_type\topic\", f_book.FileName));
                        pathTopic = @"..\Content\Doc_all_type\topic\" + f_book.FileName;
                        pathsound = @"..\Content\Doc_all_type\Sound\" + f_sound.FileName;
                        break;

                }

                if(Request.QueryString["ISBN"] == null)
                {
                    string sql = $@"INSERT INTO [dbo].[MD_catralog_book]
                           ([st_name_book]
                           ,[st_ISBN_ISSN]
                           ,[st_detail_book]
                           ,[dt_DATE_modify]
                           ,[st_type_book]
                           ,[st_type_book_name]
                           ,[bool_current]
                           ,[int_cheeckin_out]
                           ,[st_cheeckin_out]
                          
                           ,[st_process_name_user]
                           ,[int_status_yet]
                           ,[st_status_yet]
                           ,[img_path]
                           ,[video_path]
                           ,[ebook_path]
                           ,[st_lend_name]
                           ,[st_author]
                           ,[barcode]
                           ,[count_print]
                           ,[plate_print]
                           ,[company_print]
                           ,[int_lang]
                           ,[st_lang]
                           , int_count_view_book
                            , int_type_Dictionary
                            , st_type_Dictionary
                             , [st_callnumber] , sound_part )
                     VALUES
                           ('{ Convert.ToString(txt_book_name.Value, new CultureInfo("th-TH")) }' ,
                               '{ txt_iss_num.Value }',
                               '{ detail_book.Value }',
                               '{ DateTime.UtcNow.ToString("yyyy/MM/dd", new CultureInfo("en-EN")) }',
                               '{ int_types}',
                               '{st_types}',
                               '{"False"}',
                               {0},
                               '{"พร้อมยืม"}',
                               '{ Session["user"].ToString() }',
                               {0 },
                               '{""}',
                               '{pathTopic }',
                               '{ pathVideo }',
                               '{pathEbook }',
                               '{""}',
                               '{txt_author.Value }',
                               '{ txt_bar_code.Value }',
                               '{ count_print.Value }',
                               '{plate_print.Value}',
                               '{ company_print.Value }',
                               {0},
                               '{"ภาษาไทย"}' , 0 , {ddl_dictionnary.SelectedValue} , '{ddl_dictionnary.SelectedItem.Text}' , '{call_number.Value} ฉ{i}' , '{pathsound}')";

                    var result = Conncetions_db.Instance.Connection_command(sql);
                }
                else
                {
                    string sql2 = "";
                    var result = Conncetions_db.Instance.Connection_command(sql2);
                }
             

            }


        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            if (f_gen_ebook.HasFiles)
            {
                Gen_Document.Instance.MergePDF(f_gen_ebook.PostedFiles);
                Response.Write(@"<script>alert('ได้อัพโหลดไปที่ C:\\newpdf\\ เรียบร้อยแล้ว ')</script>");
            }
            
        }
    }
}