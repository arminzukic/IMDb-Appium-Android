using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using IMDb_Appium_Android.Enums;
using IMDb_Appium_Android.Helpers;

namespace IMDb_Appium_Android.Pages;

public class MoviePage : BasePage
{
    private static By Title => MobileBy.Id("com.imdb.mobile:id/title");
    private static By ImdbRating => MobileBy.Id("com.imdb.mobile:id/imdb_rating");
    private static By MetaCriticRating =>
        By.XPath(
            "//android.widget.FrameLayout[@resource-id='com.imdb.mobile:id/metacritic_score']/android.widget.TextView");

    public MoviePage(AndroidDriver driver) : base(driver)
    {
    }

    public float GetImdbRating()
    {
        var rating = GetText(ImdbRating);
        Console.WriteLine($"IMDb UI Rating: {rating}");
        
        return float.Parse(rating);
    }

    public int GetMetaCriticRating()
    {
        ScrollDown();
        var rating = GetText(MetaCriticRating);
        Console.WriteLine($"MetaCritic UI Rating: {rating}");
        
        return int.Parse(rating);
    }

    public MoviePage WaitForMovieTitleToLoad(Movies movie)
    {
        WaitForTextInElement(Title, movie.GetMovieTitle());
        
        return this;
    }
}