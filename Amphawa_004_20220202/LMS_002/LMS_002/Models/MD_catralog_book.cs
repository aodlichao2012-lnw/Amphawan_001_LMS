using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_002.Models
{
    public class MD_catralog_book
    {
         //ไฟล์ E-book
        [Key]
        public int int_id_catalog_book { get; set; }
        public int[] int_show_count_enries = new int[]
        {
            10 , 20 ,30 ,50 ,100
        };

        public string st_name_book { get; set; }
        public string st_ISBN_ISSN { get; set; }
        public string st_detail_book { get; set; }

        public DateTime dt_DATE_modify { get; set; } = DateTime.Now;

        public int st_type_book { get; set; } = 0;
        public string st_type_book_name { get; set; }
        public bool bool_current { get; set; } = false;

        //เพิ่มทีหลัง

        public int int_cheeckin_out { get; set; } = 0;
        public string st_cheeckin_out { get; set; }


        public DateTime dt_checkout_date { get; set; } = DateTime.Now;
        public DateTime dt_checkin_date { get; set; }  = DateTime.Now;
        public DateTime dt_checkin_due { get; set; } = DateTime.Now.AddMonths(1);
        public Byte[] img_book { get; set; }

        public string st_process_name_user { get; set; }
        public int int_status_yet { get; set; } = 0;
        public string st_status_yet { get; set; }
        public string img_path { get; set; }
        public string st_lend_name { get; set; }
        public string video_path { get; set; }
        public string ebook_path { get; set; }
        public string st_author { get; set; }
        public string barcode { get; set; }
        public string count_print { get; set; }
        public string plate_print { get; set; }
        public string company_print { get; set; }
        public string st_lang { get; set; }
        public int int_lang { get; set; } = 0;
        public int int_count_view_book { get; set; } = 0;
        //ไฟล์เสียง

        //ไฟล์วิดีโอ
        public int int_type_Dictionary { get; set; }
        public string st_type_Dictionary { get; set; }




    }
}
