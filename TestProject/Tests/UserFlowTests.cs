using NUnit.Framework;

[TestFixture]
public class UserFlowTests : BaseTest
{
    [Test]
    public void CompleteUserJourney()
    {
        // Step 1: Login
        DashboardPage dashboard = loginPage
            .EnterUsername("testuser@email.com")
            .EnterPassword("password123")
            .ClickLogin();
        
        // Step 2: Verify login success
        Assert.IsTrue(dashboard.IsLoggedIn(), "User should be logged in");
        
        // Step 3: Search something
        dashboard.Search("test query");
        
        // Step 4: Logout
        LoginPage logoutPage = dashboard.Logout();
        
        // Step 5: Verify logout (back to login page)
        Assert.IsTrue(driver.Url.Contains("login"), "Should be back to login page");
    }
    
    [Test]
    public void LoginWithInvalidCredentials()
    {
        loginPage
            .EnterUsername("invalid@email.com")
            .EnterPassword("wrongpassword")
            .ClickLogin();
            
        // Verify error message appears
        Assert.IsTrue(driver.PageSource.Contains("Invalid credentials"));
    }
}