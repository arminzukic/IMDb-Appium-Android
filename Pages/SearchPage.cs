using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using IMDb_Appium_Android.Enums;
using IMDb_Appium_Android.Helpers;

namespace IMDb_Appium_Android.Pages;

public class SearchPage : BasePage
{
    private static By SearchField => MobileBy.Id("com.imdb.mobile:id/search_src_text");
    
    public SearchPage(AndroidDriver driver) : base(driver)
    {
    }

    public SearchPage TapOnSearchField()
    {
        Tap(SearchField);
        
        return this;
    }

    public SearchPage EnterMovieName(Movies movie)
    {
        SendText(SearchField,movie.GetMovieTitle());
        Driver.HideKeyboard();
        
        return this;
    }

    public MoviePage TapOnMovie(Movies movie)
    {
        Tap(By.XPath($"(//android.widget.TextView[contains(@text, '{movie.GetMovieTitle()}')]/parent::*)[1]"));
        
        return new MoviePage(Driver);
    }
}