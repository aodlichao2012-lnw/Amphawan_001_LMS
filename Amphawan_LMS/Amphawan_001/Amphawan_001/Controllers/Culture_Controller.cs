using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Amphawan_001.Controllers
{
    public class Culture_Controller : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult btn_cuture([FromHeader] string name)
        {
            if (Thread.CurrentThread.CurrentCulture.Name == "TH")
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                ViewBag.CultBtn = "En";
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                ViewBag.CultBtn = "Fr";
            }

            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            TempData["cuture"] =  Thread.CurrentThread.CurrentCulture.Name;

            return   RedirectToAction("Index", "Search_");
        }
    }
}
