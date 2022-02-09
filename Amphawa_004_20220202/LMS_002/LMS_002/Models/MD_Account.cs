using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_002.Models
{
    public class MD_Account
    {
        [Key]
        public int int_id { get; set; }
        public string st_user { get; set; }
        public string st_password { get; set; }
        public string st_compare_password { get; set; }
        [EmailAddress]
        public string st_email { get; set; }
        public DateTime dt_cus_birth_day { get; set; } = DateTime.Now;
        public DateTime dt_cus_begin_cus_day { get; set; } = DateTime.Now;
        public DateTime dt_cus_expire_cus_day { get; set; } = DateTime.Now;
        public bool bool_staus { get; set; } = true;
        public bool bool_stop_ { get; set; } = false;
        public string st_cus_name { get; set; }
        public string st_post_address { get; set; }
        [EmailAddress]
        public string st_Email_address { get; set; }
        public enum enum_type_cus
        {
            standdad
        }

         public int int_type_cus { get; set; }  = Convert.ToInt32( enum_type_cus.standdad);

        public string st_type_cus { get; set; }
        public int st_count { get; set; } = 0;
        public decimal decimal_cus_from_least { get; set; } = 0;

        public DateTime Date_login_user { get; set; } = DateTime.Now;


        //public List<MD_catralog_book> Fk_Catralog_s { get; set; }
    }
}
