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
            // testing input component
            IWebElement inputelem = webDriver.FindElement(By.Id("autocomplete"));
            Input InputComp = new Input(inputelem);
            InputComp.FillInput("Hello World!");

            // testing select component
            IWebElement selectelem = webDriver.FindElement(By.Id("dropdown-class-example"));
            SelectTest selectComp = new SelectTest(selectelem);
            selectComp.selectOtptions(["Option1"]);

            // testing radio component
            IWebElement radioElem = webDriver.FindElement(By.Id("radio-btn-example"));
            RadioTest radioComp = new RadioTest(radioElem, "radioButton");

            // Find radio button by name and value
            IWebElement radioButton = webDriver.FindElement(By.CssSelector($"input[name='radioButton'][value='radio1']"));
            radioComp.selectOptionByValue(radioButton);

            // Find radio button by its label text
            // IWebElement label = driver.FindElement(By.XPath($"//label[text()='{labelText}']"));
            // radioComp.selectOptionByText(label);

            // testing checkbox component
            IWebElement checkboxElem = webDriver.FindElement(By.Id("checkbox-example"));
            CheckBoxTest checkboxComp = new CheckBoxTest(checkboxElem);
            IWebElement checkBoxOption = webDriver.FindElement(By.CssSelector($"input[name='checkBoxOption1'][value='option1']"));
            checkboxComp.checkOption(checkBoxOption);

            // testing mouse component
            IWebElement mouseElem = webDriver.FindElement(By.Id("mousehover"));
            IWebElement mouseTargetElem = webDriver.FindElement(By.CssSelector("a[href='#top']"));
            MouseTests mouseComp = new MouseTests(mouseElem, webDriver);
            mouseComp.HoverThenClickElement(mouseTargetElem);

            // testing new window component
            IWebElement windowBtn = webDriver.FindElement(By.Id("openwindow"));
            WindowTest windowTest = new WindowTest(webDriver);
            windowBtn.Click();

            if (windowTest.IsNewWindowAvailable())
            {
                windowTest.SwitchToNewWindow();

                string newWindowTitle = windowTest.GetCurrentWindowTitle();
                Console.WriteLine($"New window title: {newWindowTitle}");

                //now close and switch back to orignal window
                windowTest.CloseCurrentWindow().SwitchToOriginalWindow();
            }


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

        if (webDriver != null)
        {
            //webDriver.Quit();
            webDriver.Dispose();
        }
    }
}
