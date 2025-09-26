using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PracticePageTests;

public class SelectTest
{
    private SelectElement selectElem;

    public SelectTest(IWebElement elem)
    {
        selectElem = new SelectElement(elem);
    }

    public void selectOtptions(string[] values)
    {
        foreach (string s in values)
        {
            selectElem.SelectByText(s);
        }
    }
    
    public void deSelectOtptions(string[] values)
    {
        foreach(string s in values) {
            selectElem.DeselectByText(s);
        }
    }
}