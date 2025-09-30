using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticePageTests;

public class WindowTest
{
    private IWebDriver driver;
    private string originalWindowHandle;

    public WindowTest(IWebDriver driver)
    {
        this.driver = driver;
        originalWindowHandle = driver.CurrentWindowHandle;
    }

    public bool IsNewWindowAvailable(int timeoutSeconds = 10)
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d => d.WindowHandles.Count > 1);
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public WindowTest SwitchToNewWindow()
    {
        foreach (string windowHandle in driver.WindowHandles)
        {
            Console.WriteLine("new window id", windowHandle);
            if (windowHandle != originalWindowHandle)
            {
                driver.SwitchTo().Window(windowHandle);
                break;
            }
        }
        return this;
    }

    public WindowTest SwitchToOriginalWindow()
    {
        driver.SwitchTo().Window(originalWindowHandle);
        return this;
    }

    public string GetCurrentWindowTitle()
    {
        return driver.Title;
    }

    public int GetWindowCount()
    {
        return driver.WindowHandles.Count;
    }

    public string GetCurrentWindowHandle()
    {
        return driver.CurrentWindowHandle;
    }

    public WindowTest CloseCurrentWindow()
    {
        driver.Close();
        return this;
    }
}