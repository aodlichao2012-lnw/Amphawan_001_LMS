using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphawan_001.Controllers
{
    public class Catalog_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index_Book()
        {
            return View();
        }
    }
}
