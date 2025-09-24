using OpenQA.Selenium;

public class LoginPage : BasePage
{
    // Locators
    private By usernameField = By.Id("username");
    private By passwordField = By.Id("password");
    private By loginButton = By.Id("loginBtn");
    private By registerLink = By.LinkText("Register");
    
    public LoginPage(IWebDriver driver) : base(driver) { }
    
    public LoginPage EnterUsername(string username)
    {
        Type(usernameField, username);
        return this;
    }
    
    public LoginPage EnterPassword(string password)
    {
        Type(passwordField, password);
        return this;
    }
    
    public DashboardPage ClickLogin()
    {
        Click(loginButton);
        return new DashboardPage(driver);
    }
    
    public RegisterPage GoToRegister()
    {
        Click(registerLink);
        return new RegisterPage(driver);
    }
}