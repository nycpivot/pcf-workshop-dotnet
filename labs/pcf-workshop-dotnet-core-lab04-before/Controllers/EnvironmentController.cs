using Microsoft.AspNetCore.Mvc;

namespace pcf_workshop_dotnet_core_lab04_before.Controllers
{
    public class EnvironmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}