using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS_002.Models
{
    public class MD_status_user
    {
        [Key]
        public int self_id { get; set; }
        public string status_user { get; set; }
    }
}