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

5. Include the AppSettingsController to the project. This will just read from the config, populated from appsettings file, and store the values for the view.
6. Include the Views/AppSettings folder to the project. This file displays the ConnectionString.
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
2. Include the Views/Environment folder to the project. This file displays Application settings and bound Services.
3. Uncomment the Environment navbar menu item in Shared/_Layout.cshtml.
4. Uncomment the following line in the manifest.yml file, which will make it possible to bind services on every push.
5. Publish a Release build.
6. From the Release folder, push the app.

	cf push

8. Navigate to the Environment page to observe the output.

### STEP 3 - INJECT STEELTOE OPTIONS

1. Note the following NuGet package has been added to the project.

		Steeltoe.Extensions.Configuration.CloudFoundryCore

2. Uncomment the code in the BuildWebHost function in Program.js. The necessary line is "AddCloudFoundry()".

		WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureAppConfiguration((context, config) =>
            {
                var env = context.HostingEnvironment;

                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            })
			.AddCloudFoundry()
            .Build();

3. Open Startup.cs file.

		1. uncomment the using statement
		2. uncomment the two lines in the ConfigureServices method.

4. Include the OptionsController to the project. This will inject configuration settings into type-safe objects.
5. Include the Views/Options folder to the project. This file displays Application settings and bound Services.
6. Uncomment the Options navbar menu item in Shared/_Layout.cshtml.
7. Publish a Release build.
8. From the Release folder, push the app.

	cf push

9. Navigate to the Options page to observe the output.

### STEP 4 - GIT CONFIG SERVER & STEELTOE

1. Create a config server service. This can take several minutes.

		cf create-service p-config-server standard pcf-workshop-dotnet-config-server

2. Once it has finished creating the service, open the config.json file within the project.
	This file will be used to update the service to point to an external git repository of environmental app settings.
	Execute the following command from the same directory of the file.

	cf update-service pcf-workshop-dotnet-config-server -c config.json

4. Include the ConfigController to the project. This will inject configuration settings read from the github repository.
5. Include the Views/Config folder to the project. This file displays settings defined from the github repository.
6. Uncomment the Config navbar menu item in Shared/_Layout.cshtml.
7. Publish a Release build.
8. From the Release folder, push the app.

	cf push

9. Navigate to the Config page to observe the output.