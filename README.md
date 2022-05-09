# IMDb-Appium-Android
  Automation of the IMDb Android App using Appium and Browserstack.

  To execute tests it is recommanded to have Rider or latest Visual Studio as IDE installed since .net 6 is required.

  The scripts uses the IMDb API calls to assert the UI values for which it is required to use your own API Key to be able to send requests.
Inside the ImdbApi.cs file please provide the "<IMDb_API_KEY>" which u can generate by registering on the site: https://imdb-api.com/. 

  In order to execute tests on Browserstack, inside the ImdbAndroidBrowserStackTest.cs file you should provide "<BROWSERSTACK_USERNAME>" and "<BROWSERSTACK_ACCESS_KEY>".
The username and access key are provided by clicking the Access Key dropdown on Browserstack App Automate website section: https://app-automate.browserstack.com/.

  The last thing needed is to upload the IMDb APK file to browserstack and use the reference ID of the uploaded app as our App Capability.
The APK file can be downloaded from here: https://m.apkpure.com/imdb-your-guide-to-movies-tv-shows-celebrities/com.imdb.mobile.

  Once we have the file we can manually upload it (or programatically via CURL) in browserstack on following site: https://app-automate.browserstack.com/dashboard/v2/get-started#upload-app.

  Once we upload the app we should get the corresponding ID in the format: "bs://<app-id>". Once we use uploaded APP as our app capability we are ready to execute tests on browserstack. 

  In order to execute tests on different Android devices and different android os versions we need to change the Platform Name and Device Name capabilities inside the ImdbAndroidBrowserStackTest.cs file. The list of devices can be found here: https://www.browserstack.com/list-of-browsers-and-platforms/automate.
  
  To run the tests locally, if you do not have the Appium setup, please reference many tutorials you can find on the internet on how to correctly setup Appium locally. Once that is done, inside the ImdbAndroidLocalTest.cs file, please provide App capability as the path to the IMDb APK file on your local machine, Device Name of your android device, Platform Version as the operating system version and the UDID as the device ID (run "adb devices" in terminal to see the UDID of the android device that is connected to the machine). 
  
  Fire up the Appium server instance by running "Appium" in terminal and provide the "<SERVER_LISTENER_URI>" inside the ImdbAndroidLocalTest.cs file (comment inside the file should make it clear which listener to use).
