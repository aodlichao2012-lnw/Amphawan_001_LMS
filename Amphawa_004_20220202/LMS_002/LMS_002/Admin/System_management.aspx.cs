using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_002.Admin
{
    public partial class System_management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                library_name.Value = ConfigurationManager.AppSettings["short_name"];
                library_subname.Value = ConfigurationManager.AppSettings["full_name"];
                img_cover.Src = ConfigurationManager.AppSettings["Logo"];
                default_lang.Value = ConfigurationManager.AppSettings["Language"];
                opac_result_num.Value = ConfigurationManager.AppSettings["Count_list"];
                check_book.Value = ConfigurationManager.AppSettings["show_new_book"];
                quick_return.Value = ConfigurationManager.AppSettings["Return"];
                circulation_receipt.Value = ConfigurationManager.AppSettings["permis_print"];
                allow_loan_date_change.Value = ConfigurationManager.AppSettings["Lend_and_date_Return"];
                loan_limit_override.Value = ConfigurationManager.AppSettings["Limit_Lend"];
                allow_file_download.Value = ConfigurationManager.AppSettings["Allows_download"];
                session_timeout.Value = ConfigurationManager.AppSettings["session"];
                enable_counter_by_ip.Value = ConfigurationManager.AppSettings["visit_ip"];
                allowed_counter_ip.Value = ConfigurationManager.AppSettings["Allow_ip"];
                allowed_counter_ip.Value = ConfigurationManager.AppSettings["Time_limit"];
            }
            //System.Diagnostics.Debug.WriteLine("short name: " + ConfigurationManager.AppSettings["short_name"]);
   

            //Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
            //webConfigApp.AppSettings.Settings["short_name"].Value = "AppValue1";
            //webConfigApp.Save();

            //System.Diagnostics.Debug.WriteLine("save");

            //System.Diagnostics.Debug.WriteLine("short name: " + ConfigurationManager.AppSettings["short_name"]);
        }

        protected void Unnamed_ServerClick()
        {

        }

        protected void updateconfig_ServerClick(object sender, EventArgs e)
        {
            Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");

            //Modifying the AppKey from AppValue to AppValue1
            //webConfigApp.AppSettings.Settings["short_name"].Value = "AppValue1";

            //Save the Modified settings of AppSettings.
            //webConfigApp.Save();

            //System.Diagnostics.Debug.WriteLine("save");

            webConfigApp.AppSettings.Settings["short_name"].Value = library_name.Value;
            webConfigApp.AppSettings.Settings["full_name"].Value = library_subname.Value;
            webConfigApp.AppSettings.Settings["Logo"].Value = img_cover.Src;
            webConfigApp.AppSettings.Settings["Language"].Value = default_lang.Value;
            webConfigApp.AppSettings.Settings["Count_list"].Value = opac_result_num.Value;
            webConfigApp.AppSettings.Settings["show_new_book"].Value = check_book.Value;
            webConfigApp.AppSettings.Settings["Return"].Value = quick_return.Value;
            webConfigApp.AppSettings.Settings["permis_print"].Value = circulation_receipt.Value;
            webConfigApp.AppSettings.Settings["Lend_and_date_Return"].Value = allow_loan_date_change.Value;
            webConfigApp.AppSettings.Settings["Limit_Lend"].Value = loan_limit_override.Value;
            webConfigApp.AppSettings.Settings["Allows_download"].Value = allow_file_download.Value;
            webConfigApp.AppSettings.Settings["session"].Value = session_timeout.Value;
            webConfigApp.AppSettings.Settings["visit_ip"].Value = enable_counter_by_ip.Value;
            webConfigApp.AppSettings.Settings["Allow_ip"].Value = allowed_counter_ip.Value;
            webConfigApp.AppSettings.Settings["Time_limit"].Value = allowed_counter_ip.Value;
            webConfigApp.Save();
            CultureInfo.CurrentUICulture = new CultureInfo(ConfigurationManager.AppSettings["Language"]);


            Response.Write(@"<script>alert('บันทึกเรียบร้อย')</script>");
        }

        protected void updateconfig2_ServerClick(object sender, EventArgs e)
        {
            Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");

            //Modifying the AppKey from AppValue to AppValue1
            //webConfigApp.AppSettings.Settings["short_name"].Value = "AppValue1";

            //Save the Modified settings of AppSettings.
            //webConfigApp.Save();

            //System.Diagnostics.Debug.WriteLine("save");

            webConfigApp.AppSettings.Settings["short_name"].Value = library_name.Value;
            webConfigApp.AppSettings.Settings["full_name"].Value = library_subname.Value;
            webConfigApp.AppSettings.Settings["Logo"].Value = img_cover.Src;
            webConfigApp.AppSettings.Settings["Language"].Value = default_lang.Value;
            webConfigApp.AppSettings.Settings["Count_list"].Value = opac_result_num.Value;
            webConfigApp.AppSettings.Settings["show_new_book"].Value = check_book.Value;
            webConfigApp.AppSettings.Settings["Return"].Value = quick_return.Value;
            webConfigApp.AppSettings.Settings["permis_print"].Value = circulation_receipt.Value;
            webConfigApp.AppSettings.Settings["Lend_and_date_Return"].Value = allow_loan_date_change.Value;
            webConfigApp.AppSettings.Settings["Limit_Lend"].Value = loan_limit_override.Value;
            webConfigApp.AppSettings.Settings["Allows_download"].Value = allow_file_download.Value;
            webConfigApp.AppSettings.Settings["session"].Value = session_timeout.Value;
            webConfigApp.AppSettings.Settings["visit_ip"].Value = enable_counter_by_ip.Value;
            webConfigApp.AppSettings.Settings["Allow_ip"].Value = allowed_counter_ip.Value;
            webConfigApp.AppSettings.Settings["Time_limit"].Value = allowed_counter_ip.Value;
            webConfigApp.Save();
            CultureInfo.CurrentUICulture = new CultureInfo(ConfigurationManager.AppSettings["Language"]);

            Response.Write(@"<script>alert('บันทึกเรียบร้อย')</script>");
        }
    }
}