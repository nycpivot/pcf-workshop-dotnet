# LAB 2: SERVICES

## STEP 1 - WEB API

1. Navigate to the folder containing the lab 2 project files.
2. Open the manifest.yml file and provide a unique name.
3. Publish a Release build.

		dotnet publish -c Release

4. Navigate to the publish folder and deploy the app.

		cf push <app-name>-lab02-<your-name>

5. Navigate to url from the PCF dashboard.

## STEP 2 - CREATE AND BIND A SERVICE

1. View marketplace in Apps Manager or CLI.

		cf m|marketplace

2. View details for app-autoscaler to determine the free plan.

		cf m -s app-autoscaler

3. Create app-autoscaler from Apps Manager or CLI.

		cf create-service app-autoscaler standard pcf-workshop-auto-scaler

4. Verify creation of service.

		cf services

5. Bind a service to an app.

		cf bind-service <app-name>-lab02-<your-name> pcf-workshop-auto-scaler

6. Restage app.

		cf restage <app-name>-lab02-<your-name>
	
## STEP 3 - CONFIGURE SERVICE (APPS MANAGER ONLY)

1. Open App AutoScaler from Services tab.
2. Click Manage link in upper right corner.
3. Click the Edit link to change the Instance Limits.
4. Change Minimum to 2 and Maximum to 5.
5. Click Save.
6. Click the Edit link to change the Scaling Rules.
7. Select HTTP Throughput from the policy dropdown.
8. Set "Scale down if less than" to 2.
9. Set "Scale up if more than" to 5.
10. Toggle the bar next to the HTTP Throughput policy to enable it.
11. Click Save.
12. Back on the Auto Scaler settings, toggle the bar to Enable all settings.
13. Close window.
14. From the App tab in your Space, click on the app name.
15. In the Processes and Instances section, observe the two minimum running instances.