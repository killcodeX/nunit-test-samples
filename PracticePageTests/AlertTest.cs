using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PracticePageTests;

public class AlertTest
{
    private IWebDriver webdriver;
    public AlertTest(IWebDriver driver)
    {
        webdriver = driver;
    }

    public bool IsAlertPresent(int timeoutSeconds = 10)
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(ExpectedConditions.AlertIsPresent());
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Alert error happen", ex);
            return false;
        }
    }

    public string GetAlertTest()
    {
        IAlert alert = webdriver.SwitchTo().Alert();
        return alert.Text;
    }

    public AlertTest AcceptAlert()
    {
        IAlert alert = webdriver.SwitchTo().Alert();
        alert.Accept();
        return this;
    }

    public AlertTest DismissAlert()
    {
        IAlert alert = webdriver.SwitchTo().Alert();
        alert.Dismiss();
        return this;
    }

    public AlertTest SendTextToPrompt(string text)
    {
        IAlert alert = webdriver.SwitchTo().Alert();
        alert.SendKeys(text);
        return this;
    }

    public AlertTest AcceptAlertWithText(string text)
    {
        IAlert alert = webdriver.SwitchTo().Alert();
        alert.SendKeys(text);
        alert.Accept();
        return this;
    }
}