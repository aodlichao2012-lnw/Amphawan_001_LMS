using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amphawan_001.Models
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

        public DateTime Date_login_user { get; set; } = DateTime.Now;
    }
}
