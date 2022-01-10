using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amphawan_001.Models
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


        //ไฟล์เสียง

        //ไฟล์วิดีโอ

       

        
    }
}
