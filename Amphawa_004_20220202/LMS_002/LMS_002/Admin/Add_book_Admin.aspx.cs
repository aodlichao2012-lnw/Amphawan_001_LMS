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
                txt_bar_code.Value =         dt.Rows[0]["barcode"].ToString();
                txt_author.Value =         dt.Rows[0]["st_author"].ToString();
                txt_book_name.Value =       dt.Rows[0]["st_name_book"].ToString();
                txt_iss_num.Value =         dt.Rows[0]["st_ISBN_ISSN"].ToString();
                count_print.Value =         dt.Rows[0]["count_print"].ToString();
                plate_print.Value =          dt.Rows[0]["plate_print"].ToString();
                company_print.Value =       dt.Rows[0]["company_print"].ToString();
                year_print.Value =          dt.Rows[0]["count_print"].ToString();
                call_number.Value =         dt.Rows[0]["st_callnumber"].ToString();
                detail_book.Value =         dt.Rows[0]["st_detail_book"].ToString();
                count_book.Value =           dt.Rows[0]["count_book"].ToString();

        
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
                             , [st_callnumber] , sound_part  , count_book)
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
                               '{"ภาษาไทย"}',
                                0 ,
                                {ddl_dictionnary.SelectedValue} ,
                                '{ddl_dictionnary.SelectedItem.Text}' , 
                                '{call_number.Value} ฉ{i}' ,
                                '{pathsound}') , 
                                 {count}";

                    var result = Conncetions_db.Instance.Connection_command(sql);
                }
                else
                {
                    string sql2 = $@"UPDATE [dbo].[MD_catralog_book]
                                    SET
                                        
                                        [st_name_book]                  =      '{ Convert.ToString(txt_book_name.Value, new CultureInfo("th-TH")) }' ,
                                        [st_ISBN_ISSN]                  =         '{ txt_iss_num.Value }',
                                        [st_detail_book]                =         '{ detail_book.Value }',
                                        [dt_DATE_modify]                =         '{ DateTime.UtcNow.ToString("yyyy/MM/dd", new CultureInfo("en-EN")) }',
                                        [st_type_book]                  =         '{ int_types}',
                                        [st_type_book_name]             =         '{st_types}',
                                        [bool_current]                  =         '{"False"}',
                                        [int_cheeckin_out]              =         {0},
                                        [st_cheeckin_out]               =         '{"พร้อมยืม"}',
                                                                        =         '{ Session["user"].ToString() }',
                                        [st_process_name_user]          =         {0 },
                                        [int_status_yet]                =         '{""}',
                                        [st_status_yet]                 =         '{pathTopic }',
                                        [img_path]                      =         '{ pathVideo }',
                                        [video_path]                    =         '{pathEbook }',
                                        [ebook_path]                    =         '{""}',
                                        [st_lend_name]                  =         '{txt_author.Value }',
                                        [st_author]                     =         '{ txt_bar_code.Value }',
                                        [barcode]                       =         '{ count_print.Value }',
                                        [count_print]                   =         '{plate_print.Value}',
                                        [plate_print]                   =         '{ company_print.Value }',
                                        [company_print]                 =         {0},
                                        [int_lang]                      =           {0},
                                        [st_lang]                       =           '{"ภาษาไทย"}',
                                         int_count_view_book            =            0 ,
                                        , int_type_Dictionary           =            {ddl_dictionnary.SelectedValue} ,
                                        , st_type_Dictionary            =            '{ddl_dictionnary.SelectedItem.Text}' , 
                                         , [st_callnumber]              =            '{call_number.Value} ฉ{i}' ,
                                        , sound_part  ,                 =            '{pathsound}') , 
                                        count_book                      =             {count}
                    WHERE st_ISBN_ISSN =  '{Request.QueryString["ISBN"].ToString() }'
                                        ";
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