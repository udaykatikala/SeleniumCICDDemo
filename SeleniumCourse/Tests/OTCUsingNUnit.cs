using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumCourse.Pages;
namespace SeleniumCourse.Tests
{
    public class OTCUsingNUnit
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://flexdemo3.testnationsotc.com/");
            driver.Manage().Window.Maximize();
        }

        public void LoginToPortal()
        {
            IWebElement inpMemberid = driver.FindElement(By.Id("loginField_memberId"));
            inpMemberid.SendKeys("flex2024");
            IWebElement inpPassword = driver.FindElement(By.Id("loginField_loginPassword"));
            inpPassword.SendKeys("Nations@123");
            IWebElement btnLogin = driver.FindElement(By.XPath("(//button[contains(text(),'Login')])[1]"));
            btnLogin.Click();
        }
        [Test]
        public void HomePage()
        {
            LoginToPortal();
            Thread.Sleep(5000);
            IWebElement ddFlex = driver.FindElement(By.XPath("//div[contains(@class,'flex-dropdown')]//span[text()='Flex']"));
            Assert.IsTrue(ddFlex.Displayed);
        }

        [Test]
        public void ProductListPage()
        {
            LoginToPortal();
            Thread.Sleep(5000);
            IWebElement shopByCategories = driver.FindElement(By.XPath("//span[text()='Shop by categories']"));
            shopByCategories.Click();
            IWebElement lnkAllProducts = driver.FindElement(By.LinkText("All Products"));
            lnkAllProducts.Click();
            Thread.Sleep(3000);
            IWebElement imgProducts = driver.FindElement(By.XPath("//div[@class='product-img']"));
            Assert.IsTrue(imgProducts.Displayed);
        }

        /*[Test]
        public void OTCWithPOM()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterCredentials("flex2024", "Nations@123");
            loginPage.Login();
            HomePage homePage = new HomePage(driver);
            homePage.VerifyHomePage();
            homePage.ClickShopByCategories();
            PLPage plpage = new PLPage(driver);
            plpage.VerifyProdcutsPage();
        }*/

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }
    }
}
