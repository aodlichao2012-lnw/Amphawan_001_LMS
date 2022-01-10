using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Amphawan_001.Controllers
{
    public class Search_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult btn_cuture([FromUri] string name)
        {
            if (name == "TH")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
            }
            else if(name == "EN")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }

            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            TempData["cuture"] =  Thread.CurrentThread.CurrentCulture.Name;

            return RedirectToAction("Index", "Search_");
        }
    }
}
