using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace IMDb_Appium_Android.Pages;

public class SignInPage : BasePage
{

    private static By OkButton => MobileBy.Id("android:id/button2");
    
    public SignInPage(AndroidDriver driver) : base(driver)
    {
    }

    public SignInPage TapOnOkButton()
    {
        Tap(OkButton);
        
        return this;
    }

    public SearchPage TapOnSearchButton()
    {
        Tap(SearchButton);
        
        return new SearchPage(Driver);
    }
}