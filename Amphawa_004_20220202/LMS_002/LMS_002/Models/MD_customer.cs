using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_002.Models
{
    public class MD_customer
    {
        [Key]
        public int int_id_cus { get; set; }
        public string st_cus_no { get; set; }

    }
}
