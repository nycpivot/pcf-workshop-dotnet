using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace pcf_workshop_dotnet_core_lab04_after.Controllers
{
    public class AppSettingsController : Controller
    {
        private readonly IConfiguration config;

        public AppSettingsController(IConfiguration config)
        {
            this.config = config;
        }

        public IActionResult Index()
        {
            ViewData["ConnectionString"] = config["ConnectionString"];

            return View();
        }
    }
}