using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;

namespace pcf_workshop_dotnet_core_lab04_after.Controllers
{
    public class ConfigController : Controller
    {
        private readonly CloudFoundryApplicationOptions appOptions;
        private readonly CloudFoundryServicesOptions serviceOptions;

        public ConfigController(
            IOptions<CloudFoundryApplicationOptions> appOptions,
            IOptions<CloudFoundryServicesOptions> serviceOptions)
        {
            this.appOptions = appOptions.Value;
            this.serviceOptions = serviceOptions.Value;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}