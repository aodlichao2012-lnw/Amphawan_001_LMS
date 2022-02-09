using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS_002.Models
{
    public class MD_type_book
    {
        [Key]
        public int self_id { get; set; }
        public string Type_book { get; set; }
    }
}