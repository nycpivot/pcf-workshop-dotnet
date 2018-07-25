using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace Pcf.Workshop.Dotnet.Core.Lab04.Before
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()

                //********************************************************
                //LAB 4, STEP 1.4
                //********************************************************
                .ConfigureAppConfiguration((context, config) =>
                {
                    var env = context.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                })
                //--------------------------------------------------------

                //********************************************************
                //LAB 4, STEP 3.2
                //********************************************************
                .AddCloudFoundry()
                //--------------------------------------------------------

                .Build();
    }
}
