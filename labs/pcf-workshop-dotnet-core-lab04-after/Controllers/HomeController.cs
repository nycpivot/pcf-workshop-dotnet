using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pcf.Workshop.Dotnet.Core.Lab04.After.Models;

namespace Pcf.Workshop.Dotnet.Core.Lab04.After.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult About()
        {


            //ViewData["VCAP_APPLICATION"] = this.config["VCAP_APPLICATION"];
            //ViewData["VCAP_SERVICES"] = this.config["VCAP_SERVICES"];

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
