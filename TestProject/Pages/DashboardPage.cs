using OpenQA.Selenium;

public class DashboardPage : BasePage
{
    // Locators
    private By searchInput = By.Id("searchBox");
    private By searchButton = By.Id("searchBtn");
    private By logoutButton = By.Id("logout");
    private By welcomeMessage = By.Id("welcome");
    
    public DashboardPage(IWebDriver driver) : base(driver) { }
    
    public bool IsLoggedIn()
    {
        return driver.FindElement(welcomeMessage).Displayed;
    }
    
    public DashboardPage Search(string searchTerm)
    {
        Type(searchInput, searchTerm);
        Click(searchButton);
        return this;
    }
    
    public LoginPage Logout()
    {
        Click(logoutButton);
        return new LoginPage(driver);
    }
}