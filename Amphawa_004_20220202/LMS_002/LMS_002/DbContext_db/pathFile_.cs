using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_002.DbContext_db
{
    public class pathFile_
    {
        private static pathFile_ instance = null;

        private pathFile_()
        {

        }

        public static pathFile_ instance_
        {
            get
            {
                if(instance == null)
                {
                    instance = new pathFile_();
                }
                return instance;
            }
        }

        public string pathas(string root = "~/", string filename = "")
        {
            return HttpContext.Current.Server.MapPath(root) + filename;
        }
             
    }
}