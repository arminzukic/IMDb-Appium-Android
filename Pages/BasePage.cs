using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;

namespace IMDb_Appium_Android.Pages;

public class BasePage
{
    protected readonly AndroidDriver Driver;
    private const int DefaultTimeout = 30;
    
    protected static By HomeButton => MobileBy.AccessibilityId("Home");
    protected static By SearchButton => MobileBy.AccessibilityId("Search");
    protected static By VideoButton => MobileBy.AccessibilityId("Video");
    protected static By YouButton => MobileBy.AccessibilityId("You");

    protected BasePage(AndroidDriver driver)
    {
        Driver = driver;
    }

    protected void Tap(By element)
    {
        WaitDriver().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        new TouchAction(Driver)
            .Tap(Driver.FindElement(element))
            .Perform();
    }
    
    protected void SendText(By element, string text)
    {
        Find(element).SendKeys(text);
    }

    protected string GetText(By element)
    {
        return Find(element).Text;
    }

    protected void WaitForTextInElement(By element, string text)
    {
        WaitDriver().Until(driver => driver.FindElement(element).Text.Contains(text));
    }

    protected void ScrollDown()
    {
        var size = Driver.Manage().Window.Size;
        
        var startX = size.Width / 2;
        var startY = (int) (size.Height * 0.55);
        var endX = size.Width / 2; 
        var endY = (int) (size.Height * 0.45);
        
        var action = SwipeByCoordinates(startX, startY, endX, endY);
        IMultiAction multiAction = new MultiAction(Driver);

        multiAction.Add(action).Perform();
        Thread.Sleep(750);
    }
    
    private ITouchAction SwipeByCoordinates(int startX, int startY, int endX, int endY, int animationTimeInMilliseconds = 300)
    {
        var touchAction = new TouchAction(Driver)
            .Press(startX, startY)
            .Wait(animationTimeInMilliseconds)
            .MoveTo(endX, endY)
            .Release();

        return touchAction;
    }

    private AppiumElement Find(By element)
    {
        return (AppiumElement)WaitDriver()
            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
    }
    
    private WebDriverWait WaitDriver(int timeOutInSeconds = DefaultTimeout)
    {
        return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutInSeconds));
    }
}