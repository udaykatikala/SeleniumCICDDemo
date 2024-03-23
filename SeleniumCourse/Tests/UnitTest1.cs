using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCourse.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void LaunchAetna()
        {
            //sudo code for selenium automation

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://aetna.nationsbenefits.com");
            driver.Manage().Window.Maximize();
            IWebElement webElement = driver.FindElement(By.XPath("//input[@id='loginField_memberId']"));
            webElement.SendKeys("sravya chetty");
        }

        [Test]
        public void Demo()
        {
            // create an instance for webdriver
            IWebDriver driver = new ChromeDriver();
            //Navigate to required url
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            //maximize the window
            driver.Manage().Window.Maximize();

            // Find element

            IWebElement lnkLogin = driver.FindElement(By.LinkText("Login"));
            //perform action on the finded element

            lnkLogin.Click();

            //find username and perform action
            IWebElement inpUsername = driver.FindElement(By.Name("UserName"));
            inpUsername.SendKeys("admin");

            //find password and perform action on it
            IWebElement inpPassword = driver.FindElement(By.Id("Password"));
            inpPassword.SendKeys("password");

            //find login button and perform action on it

            IWebElement btnLogin = driver.FindElement(By.ClassName("btn-default"));
            btnLogin.Click();

        }

        [Test]
        public void OTCAutomation()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("");
            driver.Manage().Window.Maximize();

        }

    }
}