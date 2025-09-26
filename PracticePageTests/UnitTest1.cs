using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;


namespace PracticePageTests;

[TestFixture]
public class Tests
{
    private IWebDriver webDriver;
    [SetUp]
    public void Setup()
    {
        webDriver = new ChromeDriver();
webDriver.Manage().Window.Maximize();
WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
// going to URL
webDriver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");

    }

            [Test]
        public void AllTestMethod()
        {
            try
            {
                // testing input element
                IWebElement inputelem = webDriver.FindElement(By.Id("autocomplete"));
                Input InputComp = new Input(inputelem);
                InputComp.FillInput("Hello World!");

                Thread.Sleep(5000); // Wait to see search results
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public void Cleanup()
        {

            if(webDriver != null)
            {
                //webDriver.Quit();
                webDriver.Dispose();
            }
        }
}
