using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PracticePageTests;

public class FrameTest
{
    private IWebDriver webDriver;
    public FrameTest(IWebDriver driver)
    {
        webDriver = driver;
    }

    public bool IsFrameAvailable(By frameLocator, int delay = 10)
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(delay));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frameLocator));
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public FrameTest SwitchToFrame(IWebElement frameElement)
    {
        webDriver.SwitchTo().Frame(frameElement);
        return this;
    }

    public FrameTest SwitchToDefaultContent()
    {
        webDriver.SwitchTo().DefaultContent();
        return this;
    }

    public FrameTest SwitchToParentFrame()
    {
        webDriver.SwitchTo().ParentFrame();
        return this;
    }

    public int GetFrameCount()
    {
        return webDriver.FindElements(By.TagName("iframe")).Count;
    }
}