using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_002.Models
{
    public class md_GMDGeneral_Material_Designation
    {
        [Key]
        public int int_id_gmd { get; set; }
        public string st_type_tool { get; set; }
        public string st_name_tool { get; set; }

    }
}
