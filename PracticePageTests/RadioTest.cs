using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticePageTests;

public class RadioTest
{
    private IWebElement radioElem;
    private string radioGroupName;

    public RadioTest(IWebElement elem, string radioGroupName)
    {
        radioElem = elem;
        this.radioGroupName = radioGroupName;
    }

    public void selectOptionByValue(IWebElement radioButton)
    {
        radioButton.Click();
    }

    public void selectOptionByText(IWebElement radioButton)
    {
        radioButton.Click(); // Click the label to select radio
    }

    public bool isOptionSelected(IWebElement radioButton)
    {
        return radioButton.Selected;
    }
}