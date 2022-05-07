using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using IMDb_Appium_Android.Enums;
using IMDb_Appium_Android.Helpers;
using IMDb_Appium_Android.Pages;

namespace IMDb_Appium_Android.Test;

public class ImdbAndroidBrowserStackTest
{
    private readonly AndroidDriver _driver;
    private static readonly Uri Uri = new("http://hub-cloud.browserstack.com/wd/hub");
    
    private const string Username = "<BROWSERSTACK_USERNAME>";
    private const string AccessKey = "<BROWSERSTACK_ACCESS_KEY>";
    
    private readonly SignInPage _signInPage;
    
    public ImdbAndroidBrowserStackTest()
    {
        var appiumOptions = new AppiumOptions
        {
            App = "<BROWSERSTACK_UPLOADED_IMDB_APP>",
            PlatformName = "android",
            PlatformVersion = "12.0",
            DeviceName = "Google Pixel 6"
        };
        var browserstackOptions = new Dictionary<string, object>
        {
            {"userName", Username},
            {"accessKey", AccessKey},
            {"projectName", "IMDB OPS"},
            {"sessionName", "Check Movie Rating"},
            {"buildName", "IMDB Production Build"},
            {"debug", "true"},
            {"networkLogs", "true"}
        };
        appiumOptions.AddAdditionalAppiumOption("bstack:options", browserstackOptions);
        appiumOptions.AddAdditionalAppiumOption("autoGrantPermissions", "true");
        
        _driver = new AndroidDriver(Uri, appiumOptions);
        
        _signInPage = new SignInPage(_driver);
    }
    
    [OneTimeTearDown]
    public void Quit()
    {
        var passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
        ((IJavaScriptExecutor) _driver).ExecuteScript(
            "browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"" +
            (passed ? "passed" : "failed") + "\", \"reason\": \" " +
            (passed ? "UI and API values for ratings match!" : "UI and API values for ratings do not match!") + " \"}}");
        
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
    public void MovieRatingCheck(Movies movie)
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