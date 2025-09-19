using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; // important to use for using select dropdown
using NUnit.Framework;

namespace TestProject1
{
    class Tests2
    {
        private IWebDriver webdriver;

        [SetUp]
        public void setup() {

            webdriver = new ChromeDriver();
        }

        [Test]
        public void test() {

            // naviagte to the url
            webdriver.Navigate().GoToUrl("http://localhost:5173/");
            try
            {

                // fetch elements
                IWebElement name = webdriver.FindElement(By.Id("name"));
                IWebElement email = webdriver.FindElement(By.Id("email"));
                IWebElement btn = webdriver.FindElement(By.CssSelector("#root > div > form > button"));

                // fetching single select element
                IWebElement singledropdownElement = webdriver.FindElement(By.Id("dropdown"));

                //fetching multi select element
                IWebElement multidropdownElement = webdriver.FindElement(By.Id("multi-dropdown"));

                // check if the field is not null
                Assert.IsNotNull(name, "Name field should not be null");
                Assert.IsNotNull(email, "Email field should not be null");
                Assert.IsNotNull(singledropdownElement, "single dropdown field should not be null");
                Assert.IsNotNull(multidropdownElement, "multi dropdown field should not be null");
                Assert.IsNotNull(btn, "Submit button should not be null");


                // Adding action to the element

                // Fill in the form
                name.SendKeys("Aaquib Ahmad");
                email.SendKeys("test@email.com");

                // select single item from single dropdown
                SelectElement singledropdown = new SelectElement(singledropdownElement);
                singledropdown.SelectByText("Not Employed");

                // select multiple item from multi dropdown
                SelectElement multidropdown = new SelectElement(multidropdownElement);
                multidropdown.DeselectAll(); // clearing any preselected values
                multidropdown.SelectByValue("Monday");
                multidropdown.SelectByValue("Tuesday");

                Assert.AreEqual(2, multidropdown.AllSelectedOptions.Count); // verifying if two item selected
                var selectedValues = multidropdown.AllSelectedOptions.Select(o => o.GetAttribute("value")).ToList(); // fetching all selected items
                Assert.Contains("Monday", selectedValues); // verifying if selected items contain "Monday"
                Assert.Contains("Tuesday", selectedValues); // verifying if selected items contain "Tuesday"

                // click to submit
                btn.Click();
            } catch (Exception ex)
            {
                Assert.Fail("Some error happened!", ex.Message);
            }
        }

        [TearDown]
        public void conclusion() { 
        
            if(webdriver != null)
            {
                webdriver.Quit();
            }
        }
    }
}
