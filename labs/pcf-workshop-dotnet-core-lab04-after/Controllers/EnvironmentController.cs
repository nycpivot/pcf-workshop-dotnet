using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace pcf_workshop_dotnet_core_lab04_after.Controllers
{
    public class EnvironmentController : Controller
    {
        private readonly IConfiguration config;

        public EnvironmentController(IConfiguration config)
        {
            this.config = config;
        }

        public IActionResult Index()
        {
            ViewData["VCAP_APPLICATION"] = this.config["VCAP_APPLICATION"];
            ViewData["VCAP_SERVICES"] = this.config["VCAP_SERVICES"];

            return View();
        }
    }
}