## LAB 4: CONFIGURATION

### STEP 1 - READ APPSETTINGS

1. Open the lab04-before project.
2. Include the following two appsettings.json files to the project.

		1) appsettings.staging.json
		2) appsettings.production.json

3. Note the ConnectionString key set to the appropriate environment.
4. Uncomment the code in the BuildWebHost function in Program.js.

		WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureAppConfiguration((context, config) =>
            {
                var env = context.HostingEnvironment;

                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            })
            .Build();

	This code is used when configuration values should be read from settings files compiled with the code.
	It will be shortly, however, that appsettings can be overriden from other configuration sources.

5. Include the AppSettingsController.
6. Include the AppSettings.cshtml view.
7. Publish a Release build.

8. From the Release folder, push the app.

		cf push

9. Set the ASPNETCORE_ENVIRONMENT variable to either development, staging, or production.

		cf set-env [app-name]-[your-name]-lab04 ASPNETCORE_ENVIRONMENT staging

10. Navigate to the About page and observe the corresponding configuration setting output.

### STEP 2 - READ ENVIRONMENT VARIABLES

1. In the HomeController, uncomment the constructor following two lines in the About action.

		ViewData["VCAP_APPLICATION"] = this.config["VCAP_APPLICATION"];
        ViewData["VCAP_SERVICES"] = this.config["VCAP_SERVICES"];

2. In the About.cshtml view, uncomment the following lines.

		<h2>VCAP_APPLICATION</h2>
		<p>@ViewData["VCAP_APPLICATION"]</p>

		<h2>VCAP_SERVICES</h2>
		<p>@ViewData["VCAP_SERVICES"]</p>

3. Note in the manifest.yml file, we are binding to the service created in Lab 2, Step 2.3 while pushing the app in one step.
4. Publish a Release build.
5. From the Release folder, push the app.

	cf push

6. Set the ASPNETCORE_ENVIRONMENT variable to either development, staging, or production.

		cf set-env [app-name]-[your-name]-lab04 ASPNETCORE_ENVIRONMENT staging

7. Navigate to the About page to observe the corresponding configuration setting output.

### STEP 3 - INJECT STEELTOE OPTIONS

1. Add the following Steeltoe Nuget packages to the project.

		Steeltoe.Extensions.Configuration.CloudFoundryCore

2. Open Startup.cs file.

		1. uncomment the using statement
		2. uncomment the two lines in the ConfigureServices method.

3. Open the HomeController, and 1) uncomment the constructor