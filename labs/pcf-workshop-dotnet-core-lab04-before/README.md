## LAB 4: CONFIGURATION

### STEP 1 - READ APPSETTINGS

1. Open the lab04-before project.
2. Include the following two appsettings.json files to the project.

		1) appsettings.staging.json
		2) appsettings.production.json

3. Note the ConnectionString key set to the environment by the file of the same name.
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

5. Include the AppSettingsController. This will just read from the config, populated from appsettings file, and store the values for the view.
6. Include the Views/AppSettings folder. This file displays the ConnectionString.
7. Uncomment the App Settings navbar menu item in Shared/_Layout.cshtml.
8. Uncomment the following line in the manifest.yml file, which will set environment variables on every push.

		env:
			ASPNETCORE_ENVIRONMENT: staging

9. Publish a Release build.
10. From the Release folder, push the app.

		cf push

11. Navigate to the About page and observe the corresponding configuration setting output.
	The ConnectionString should reflect the same value as the ASPNETCRE_ENVIRONMENT set in the manifest.yml file.

12. This can be changed by changing the environment variable from the command line.
	Set the ASPNETCORE_ENVIRONMENT variable to production.

		cf set-env [app-name]-[your-name]-lab04 ASPNETCORE_ENVIRONMENT production
		cf restage [app-name]-[your-name]-lab04

13. Refresh the App Settings page and confirm the change.

### STEP 2 - READ ENVIRONMENT VARIABLES

1. Include the EnvironmentController to the project. This will just read from the config, populated from environment variables, and store the values for the view.
2. Include the Views/Environment folder. This file displays Application settings and bound Services.
3. Uncomment the Environment navbar menu item in Shared/_Layout.cshtml.
4. Uncomment the following line in the manifest.yml file, which will make it possible to bind services on every push.
5. Publish a Release build.
6. From the Release folder, push the app.

	cf push

8. Navigate to the Environment page to observe the output.

### STEP 3 - INJECT STEELTOE OPTIONS

1. Add the following Steeltoe Nuget packages to the project.

		Steeltoe.Extensions.Configuration.CloudFoundryCore

2. Open Startup.cs file.

		1. uncomment the using statement
		2. uncomment the two lines in the ConfigureServices method.

3. Open the HomeController, and 1) uncomment the constructor