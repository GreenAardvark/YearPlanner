using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YearPlanner.Web.Models;

namespace YearPlanner.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var now = DateTime.Now;
            var year = new Year(now.Year);
            var vm = new IndexViewModel
            {
                YearValue = now.Year,
                Year = year
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
