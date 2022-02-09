using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS_002.Models
{
    public class MD_Role
    {
        [Key]
        public int int_id_role { get; set; }
        public string st_name_role { get; set; }
    }
}