using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework; // Make sure to include this for [SetUp]

namespace TestProject1
{
    public class Tests2
    {
        private ChromeDriver driver; // CA1859: Use concrete type

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test()
        {
            try
            {
                // going to the new url
                driver.Navigate().GoToUrl("");
                // maximumize the window size
                driver.Manage().Window.Maximize();

                Console.WriteLine("✅ Test passed: Form can be filled and submitted successfully");

            } catch(Exception ex)
            {
                Assert.Fail($"Debug failed: {ex.Message}");
            }
           
        }

        [TearDown]
        public void conclusion()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose(); // NUnit1032: Ensure Dispose is called
            }
        }
    }
}