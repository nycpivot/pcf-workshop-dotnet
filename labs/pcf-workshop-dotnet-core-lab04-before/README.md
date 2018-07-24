## LAB 4: CONFIGURATION

### STEP 1 - READ APPSETTINGS

1. Navigate to the lab04-after project folder.
2. Add two appsettings.json files, one called appsettings.staging.json, and another appsettings.production.json.
3. Add any custom setting in each file that identifies the environment with that file, i.e., "Message": "Hello Staging".
4. Add json files to the configuration in the BuildWebHost function in Program.js.

		WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureAppConfiguration((context, config) =>
            {
                var env = context.HostingEnvironment;

                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            })
            .Build();

5. In the About action of HomeController, add the following code to capture the environment value from appsettings.json.

		ViewData["Environment"] = this.config["Environment"];

6. Replace the ViewData["Message"] line in the About.cshtml view with the following.

		<h3>Lab 4 @ViewData["Environment"]</h3>

7. Publish a Release build.

8. From the Release folder, push the app.

		cf push

9. Set the ASPNETCORE_ENVIRONMENT variable to either development, staging, or production.

		cf set-env [app-name]-[your-name]-lab04 ASPNETCORE_ENVIRONMENT staging

10. Navigate to the About page to observe the corresponding configuration setting output.

### STEP 2 - READ ENVIRONMENT VARIABLES

1. In the About action of HomeController, add the following two lines, under the line added in Step 1.5.

		ViewData["VCAP_APPLICATION"] = this.config["VCAP_APPLICATION"];
        ViewData["VCAP_SERVICES"] = this.config["VCAP_SERVICES"];

2. In the About.cshtml view, add the following lines under those added in Step 1.6.

		<h2>VCAP_APPLICATION</h2>
		<p>@ViewData["VCAP_APPLICATION"]</p>

		<h2>VCAP_SERVICES</h2>
		<p>@ViewData["VCAP_SERVICES"]</p>

3. Publish a Release build.
4. From the Release folder, push the app.

	cf push

5. Set the ASPNETCORE_ENVIRONMENT variable to either development, staging, or production.

		cf set-env [app-name]-[your-name]-lab04 ASPNETCORE_ENVIRONMENT staging

6. Navigate to the About page to observe the corresponding configuration setting output.