using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pcf.Workshop.Dotnet.Core.Lab04.Before.Models;

namespace Pcf.Workshop.Dotnet.Core.Lab04.Before.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConfiguration config;

        //public HomeController(IConfiguration config)
        //{
        //    this.config = config;
        //}

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
            //************************************************************
            //LAB 4, STEP 1.5
            //************************************************************
            //ViewData["Environment"] = this.config["Environment"];
            //------------------------------------------------------------


            //************************************************************
            //LAB 4, STEP 2.1
            //************************************************************
            //ViewData["VCAP_APPLICATION"] = this.config["VCAP_APPLICATION"];
            //ViewData["VCAP_SERVICES"] = this.config["VCAP_SERVICES"];
            //------------------------------------------------------------

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
