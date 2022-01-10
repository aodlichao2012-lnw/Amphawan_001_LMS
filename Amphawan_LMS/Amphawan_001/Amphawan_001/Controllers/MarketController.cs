using Amphawan_001.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphawan_001.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index_Book()
        {
            return View();
        }


        public IActionResult search()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult search([FromBody] MD_catralog_book mD_Catralog_Book)
        {
            return View();
        }

        public IActionResult Lend()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Lend([FromBody] MD_catralog_book mD_Catralog_Book)
        {
            return View();
        }

        public IActionResult returns()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult returns([FromBody] MD_catralog_book mD_Catralog_Book)
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
