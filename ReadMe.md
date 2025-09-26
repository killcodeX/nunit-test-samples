# Nunit sample Testing codes

### Repo structure

```
TestProject/ (your main repo)
├── PracticePageTests/     ← Selenium tests for practice page
│   ├── PracticePageTests.csproj
│   ├── BaseTest.cs
│   └── LoginTests.cs
├── APITests/              ← API tests
│   ├── APITests.csproj
│   └── ApiTest.cs
├── UnitTests/             ← Unit tests
│   ├── UnitTests.csproj
│   └── UnitTest.cs
└── TestProject.sln        ← Solution file (optional)
```

### Step 1: To create new Test Project

Navigate to your main repo folder and create separate test projects:

```bash
cd TestProject

# Create different test projects such as PracticePageTests, APITests
dotnet new nunit -n PracticePageTests
dotnet new nunit -n APITests
dotnet new nunit -n UnitTests
```

### Step 2: Add Selenium to Specific Projects

Add Selenium only to the projects that need it:

```bash
# Add Selenium to PracticePageTests
cd PracticePageTests
dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
cd ..

# Add HTTP client to API tests
cd APITests
dotnet add package RestSharp
cd ..
```

### Step 3: Run Tests from Specific Folders

#### Option 1: Run from Specific Folder

```bash
# Run only PracticePageTests
cd PracticePageTests
dotnet test

# Run only API tests
cd APITests
dotnet test

# Run only Unit tests
cd UnitTests
dotnet test
```

#### Option 2: Run from Root Directory

```bash
# Run specific project from root
dotnet test PracticePageTests/
dotnet test APITests/
dotnet test UnitTests/

# Run specific test file
dotnet test PracticePageTests/ --filter "TestCategory=Login"
```

### Step 4: Organize with Categories (Optional)

In your test files, use categories to further organize:

```csharp
/ In PracticePageTests/LoginTests.cs
[TestFixture]
public class LoginTests
{
    [Test, Category("Smoke")]
    public void ValidLogin() { }

    [Test, Category("Regression")]
    public void InvalidLogin() { }
}
```

Then run specific categories:

```bash
cd PracticePageTests
dotnet test --filter "TestCategory=Smoke"
```
