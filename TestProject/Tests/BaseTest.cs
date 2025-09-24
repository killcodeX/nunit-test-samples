using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class BaseTest
{
    protected IWebDriver driver;
    protected LoginPage loginPage;
    
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://yourapp.com/login");
        loginPage = new LoginPage(driver);
    }
    
    [TearDown]
    public void Cleanup()
    {
        driver?.Quit();
    }
}