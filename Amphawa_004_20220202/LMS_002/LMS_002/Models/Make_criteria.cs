using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_002.Models
{
    public static class Make_criteria
    {
        private static string make_string_criteria(MD_catralog_book mD_Catralog_)
        {
            string res = "";

            if (mD_Catralog_.st_name_book != "")
            {
                res = " st_name_book like '%" + mD_Catralog_.st_name_book + "%'" + " ";
            }

            if (mD_Catralog_.st_ISBN_ISSN != "")
            {
                if (res != "")
                {
                    res = res + " and  st_ISBN_ISSN like '%" + mD_Catralog_.st_ISBN_ISSN + "%'   ";
                }

            }


            return res;
        }
    }
}