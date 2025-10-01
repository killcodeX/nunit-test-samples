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

            Thread.Sleep(2000);

            // testing mouse component
            IWebElement mouseElem = webDriver.FindElement(By.Id("mousehover"));
            IWebElement mouseTargetElem = webDriver.FindElement(By.CssSelector("a[href='#top']"));
            MouseTests mouseComp = new MouseTests(mouseElem, webDriver);
            mouseComp.HoverThenClickElement(mouseTargetElem);

            Thread.Sleep(2000);

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

            Thread.Sleep(2000);

            // testing new tab component
            IWebElement tabBtn = webDriver.FindElement(By.Id("opentab"));
            WindowTest tabTest = new WindowTest(webDriver);
            tabBtn.Click();

            if (tabTest.IsNewWindowAvailable())
            {
                tabTest.SwitchToNewWindow();

                string newWindowTitle = tabTest.GetCurrentWindowTitle();
                Console.WriteLine($"New window title: {newWindowTitle}");

                //now close and switch back to orignal window
                tabTest.CloseCurrentWindow().SwitchToOriginalWindow();
            }

            Thread.Sleep(2000);

            // testing alert component
            IWebElement alertBtn = webDriver.FindElement(By.Id("alertbtn"));
            IWebElement confirmBtn = webDriver.FindElement(By.Id("confirmbtn"));
            AlertTest alertComp = new AlertTest(webDriver);
            alertBtn.Click();

            if (alertComp.IsAlertPresent())
            {
                alertComp.AcceptAlert();
            }

            Thread.Sleep(2000);

            // testing alert component
            confirmBtn.Click();

            if (alertComp.IsAlertPresent())
            {
                alertComp.AcceptAlert();
            }

            // testing Iframe component
            FrameTest frameComp = new FrameTest(webDriver);
            Console.WriteLine("Before switching to frame");

            if (frameComp.IsFrameAvailable(By.Id("courses-iframe")))
            {
                Console.WriteLine("Successfully switched to frame!");

                // Now interact with elements INSIDE the frame
                IWebElement link = webDriver.FindElement(By.XPath("/html/body/div/header/div[3]/div/div/div[2]/nav/div[2]/ul/li[2]/a"));
                link.Click();

                // Switch back to main page
                frameComp.SwitchToDefaultContent();

                Console.WriteLine("Switched back to main page");
            }
            else
            {
                Console.WriteLine("Frame not found!");
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
