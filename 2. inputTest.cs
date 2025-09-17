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
                driver.Navigate().GoToUrl("http://localhost:5173/");
                // maximumize the window size
                driver.Manage().Window.Maximize();

                // Verify page loaded correctly
                Assert.IsTrue(driver.Title.Length > 0, "Page should have a title");

                // Verify form elements exist
                IWebElement nameField = driver.FindElement(By.Id("name"));
                IWebElement emailField = driver.FindElement(By.Id("email"));
                IWebElement submitButton = driver.FindElement(By.XPath("//button[@type='submit']"));

                Assert.IsNotNull(nameField, "Name field should exist");
                Assert.IsNotNull(emailField, "Email field should exist");
                Assert.IsNotNull(submitButton, "Submit button should exist");

                // Fill in the form
                nameField.SendKeys("Aaquib Ahmad");
                emailField.SendKeys("test@email.com");


                // Verify values were entered
                Assert.AreEqual("Aaquib Ahmad", nameField.GetAttribute("value"), "Name should be entered correctly");
                Assert.AreEqual("test@email.com", emailField.GetAttribute("value"), "Email should be entered correctly");

                // Click the submit button
                submitButton.Click();

                // Since your form prevents default and doesn't change the page,
                // we can verify that we're still on the same page and form values persist
                Assert.AreEqual("http://localhost:5173/", driver.Url, "Should remain on the same page after submit");

                // Verify form values are still there (since your code doesn't clear them)
                Assert.AreEqual("Aaquib Ahmad", nameField.GetAttribute("value"), "Name should persist after submit");
                Assert.AreEqual("test@email.com", emailField.GetAttribute("value"), "Email should persist after submit");

                // Wait a moment to see the result
                System.Threading.Thread.Sleep(2000);

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