using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LMS_002.DbContext_db
{
    public class Gen_Document
    {
        private Gen_Document()
        {

        }

        private static Gen_Document instnace = null;

        public static Gen_Document Instance
        {
            get
            {
                if (instnace == null)
                {
                    instnace = new Gen_Document();
                }
                return instnace;
            }
        }

        public void MergePDF(IList<HttpPostedFile> filenme, string[] filenames_fromarray = null)
        {
            string outputfile = $@"newfile{DateTime.UtcNow.ToOADate()}.pdf";
            string root = Directory.CreateDirectory(@"C:\newpdf\").FullName;
            var fs = new FileStream(root+outputfile, FileMode.Create);
            var conc = new PdfConcatenate(fs, true);
            foreach (var s in filenme)
            {
                s.SaveAs(pathFile_.instance_.pathas(@"~\Gen_book\", s.FileName));
                var r = new PdfReader(pathFile_.instance_.pathas(@"~\Gen_book\", s.FileName));
                conc.AddPages(r);
            }
            conc.Close();

        }
    }
}