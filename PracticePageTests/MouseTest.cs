using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PracticePageTests;

public class MouseTests
{
    private IWebElement mouseElem;
    private Actions actions;

    public MouseTests(IWebElement elem, IWebDriver webdriver)
    {
        mouseElem = elem;
        actions = new Actions(webdriver);
    }

    public MouseTests HoverElement()
    {
        actions.MoveToElement(mouseElem).Perform();
        return this;
    }

    public MouseTests ClickElement()
    {
        actions.Click(mouseElem).Perform();
        return this;
    }

    public MouseTests RightClickElement()
    {
        actions.ContextClick(mouseElem).Perform();
        return this;
    }
    public MouseTests HoverThenClickElement(IWebElement targetElement)
    {
        actions.MoveToElement(mouseElem)                    // Hover first element
               .Pause(TimeSpan.FromMilliseconds(500))     // Wait
               .MoveToElement(targetElement)              // Move to target
               .Click()                                   // Click target
               .Perform();                                // Execute all at once
        return this;
    }

    public static void DragAndDrop(IWebDriver driver, IWebElement source, IWebElement target)
    {
        new Actions(driver).DragAndDrop(source, target).Perform();
        // No return needed - it's a complete action
    }
}