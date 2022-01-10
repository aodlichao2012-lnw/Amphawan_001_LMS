using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphawan_001.Controllers
{
    public class Search_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
