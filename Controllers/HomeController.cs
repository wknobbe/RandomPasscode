using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            int? counter = HttpContext.Session.GetInt32("counter");
            if(counter == null)
            {
                counter = 1;
                HttpContext.Session.SetInt32("counter", (int) counter);
            }
            else
            {
                counter++;
                HttpContext.Session.SetInt32("counter", (int) counter);
            }
            string code = new Passcode().Code;
            Dictionary<string,object> info = new Dictionary<string, object>();
            info["counter"] = (int) counter;
            info["code"] = (string) code;
            return View(info);
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
