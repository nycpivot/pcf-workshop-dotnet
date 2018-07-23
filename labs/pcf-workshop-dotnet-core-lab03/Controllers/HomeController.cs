using System;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Pcf.Workshop.Dotnet.Core.Lab03.Models;

namespace Pcf.Workshop.Dotnet.Core.Lab03.Controllers
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
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //****************************************************************
        //SECTION 1, STEP 3
        //ADD A KILL ACTION THAT OUTPUTS A VERBOSE LOG AND AN ERROR LOG,
        //AND RETURNS NULL AND TERMINATES THE APP
        //****************************************************************
        public void Kill()
        {
            Console.WriteLine("KILL STARTED");

            var message = "BYE WORLD";

            Console.OpenStandardError().Write(
                Encoding.ASCII.GetBytes(message), 0, message.Length);

            Environment.Exit(0);

            //exhaust memory
            //while (true) { Marshal.AllocHGlobal(1024); }

            //spike CPU
            //while (true)
            //{
            //    Process.Start(Assembly.GetExecutingAssembly().Location);
            //}
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
