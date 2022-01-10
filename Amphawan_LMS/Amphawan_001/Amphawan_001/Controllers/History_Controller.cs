using Amphawan_001.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphawan_001.Controllers
{
    public class History_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        
        public IActionResult search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult search(string id)
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult print_report(string id)
        {
            return View();
        }

    }
}
