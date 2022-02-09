using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS_002.Models
{
    public class MD_Dictionary
    {
        [Key]
        public int int_id_type_Dictionary { get; set; }
        public string st_type_Dictionary { get; set; }
    }
}