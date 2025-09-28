using OpenQA.Selenium;

namespace PracticePageTests;

public class CheckBoxTest
{
    private IWebElement checkboxElem;

    public CheckBoxTest(IWebElement elem)
    {
        checkboxElem = elem;
    }

    public void checkOption(IWebElement option)
    {
        option.Click();
    }

    public void verifyChecked(IWebElement option)
    {
        //option.
    }
}