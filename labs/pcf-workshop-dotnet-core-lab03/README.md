# Lab 3: Self Healing & Zero-Downtime Deployment

## STEP 1 - Self Healing

1. Navigate to the lab 3 project folder.
2. Publish a Release build.

		dotnet publish -c Release

3. From the publish folder, deploy the app.

		cf push

4. Navigate to url.
5. On the About menu, click Kill link.
6. From the command line, keep issuing the following command.

		cf app [app-name]-[your-name]-lab03

6. Observe one of the instances crash, then restored.
7. Check logs in Apps Manager or CLI.

		cf logs [app-name]-[your-name]-lab03 --recent

## STEP 2 - Blue-Green Deployment

1. Edit the footer text on the _Layout.cshtml page to indicate a new version, i.e., 2018 - Pcf.Workshop.Core.Lab03 2.0
2. Rebuild and publish again.
3. Override the parameters in the manifest.yml file from the command line.

		cf push [app-name]-[your-name]-lab03 -n [app-name]-[your-name]-lab03-v2

4. Observe both versions running in parallel.
5. After testing, the app is ready to replace the older version.
6. Map the route from the v1 app to the v2 app. This will give v2 both routes (v1, v2).

		cf map-route [app-name]-[your-name]-lab03 <DOMAIN> -n [app-name]-[your-name]-lab03-v2

7. Unmap the route that was given to v2 used to test, leaving both apps with the same route.

		cf unmap-route [app-name]-[your-name]-lab03 <DOMAIN> -n [app-name]-[your-name]-lab03

8. Unmap the route assigned to lab03 to prevent any further requests.

		cf unmap-route [app-name]-[your-name]-lab03 <DOMAIN> -n [app-name]-[your-name]-lab03

9. Confirm updates to web page reflect lab03 version.
10. Delete original app.

		cf delete [app-name]-[your-name]-lab03

11. Delete orphaned routes.

		cf delete-orphaned-routes