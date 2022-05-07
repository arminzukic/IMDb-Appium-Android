using System;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using IMDb_Appium_Android.Enums;
using IMDb_Appium_Android.Helpers;
using IMDb_Appium_Android.Pages;

namespace IMDb_Appium_Android.Test;

public class ImdbAndroidLocalTest
{
    private readonly AndroidDriver _driver;
    //For Appium version below 2.0 use "http://localhost:4723/wd/hub", for Appium 2.0 use "http://localhost:4723"
    private static readonly Uri Uri = new("<SERVER_LISTENER_URI>");
    
    private readonly SignInPage _signInPage;

    public ImdbAndroidLocalTest()
    {
        var appiumOptions = new AppiumOptions
        {
            App = "<PATH_TO_IMDB_APK_FILE>",
            AutomationName = "uiautomator2",
            PlatformName = "android",
            PlatformVersion = "<PLATFORM_VERSION>",
            DeviceName = "<DEVICE_NAME>"
        };
        appiumOptions.AddAdditionalAppiumOption("appium:udid", "<UDID_ANDROID_DEVICE>");
        appiumOptions.AddAdditionalAppiumOption("appium:fullReset", "true");
        appiumOptions.AddAdditionalAppiumOption("appium:autoGrantPermissions", "true");
        appiumOptions.AddAdditionalAppiumOption("appium:appActivity", "com.imdb.mobile.HomeActivity");

        _driver = new AndroidDriver(Uri, appiumOptions);
        
        _signInPage = new SignInPage(_driver);
    }

    [TearDown]
    public void Quit()
    {
        _driver.Quit();
    }
    
    [TestCase(Movies.ManchesterByTheSea)]
    [TestCase(Movies.TheLordOfTheRingsReturnOfTheKing)]
    [TestCase(Movies.TheThinRedLine)]
    [TestCase(Movies.LostInTranslation)]
    [TestCase(Movies.BlackHawkDawn)]
    [TestCase(Movies.Inception)]
    [TestCase(Movies.ApocalypseNow)]
    [TestCase(Movies.JurassicPark)]
    [TestCase(Movies.TheNorthman)]
    [TestCase(Movies.TheLastOfTheMohicans)]
    [TestCase(Movies.TheBatman)]
    [TestCase(Movies.Gladiator)]
    [TestCase(Movies.Dune)]
    [TestCase(Movies.GoodWillHunting)]
    [TestCase(Movies.EternalSunshineOfASpotlessMind)]
    public void MovieScoresCheck(Movies movie)
    {
        var movieApiRating = ImdbApi.GetRatings(movie.GetMovieTitle(), movie.GetMovieYear());
        
        var moviePage = _signInPage.TapOnOkButton()
            .TapOnSearchButton()
            .TapOnSearchField()
            .EnterMovieName(movie)
            .TapOnMovie(movie)
            .WaitForMovieTitleToLoad(movie);

        using (new AssertionScope())
        {
            moviePage.GetMetaCriticRating().Should().Be(ImdbApi.GetMetaCriticRating(movieApiRating));
            moviePage.GetImdbRating().Should().Be(ImdbApi.GetImdbRating(movieApiRating));
        }
    }
}