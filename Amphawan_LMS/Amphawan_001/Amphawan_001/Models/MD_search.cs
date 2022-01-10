using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amphawan_001.Models
{
    public class MD_search
    {
        [Key]
        public int int_id_num { get; set; }
        public enum enum_type_ebook
        {
            books , digital_cllection , ebook , video
        }
        public enum enum_kind_book{
            keyword , title , author , other
        }
        public string st_keyword { get; set; }

        public int int_order_by { get; set; }

    }
}
