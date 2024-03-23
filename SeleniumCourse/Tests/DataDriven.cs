using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumCourse.Pages;
using Newtonsoft.Json;
using SeleniumCourse.Drivers;
using SeleniumCourse.Config;

namespace SeleniumCourse.Tests
{
    public class DataDriven 
    {
        private Driver driver;

        private DriverWait driverWait;

        public DataDriven()
        {
            var testSettings = ConfigReader.ReadConfig();

            driver = new Driver(testSettings);

            driverWait = new DriverWait(driver, testSettings);
        }


        /* [SetUp]
         public void SetUp()
         {
             ChromeOptions options = new ChromeOptions();
             options.AddArgument("--incognito");
             driver = new ChromeDriver(options);
             driver.Navigate().GoToUrl("https://flexdemo3.testnationsotc.com/");
             driver.Manage().Window.Maximize();
         }*/

        [Test]
        public void OTCWithPOM()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);
            dynamic jsonData = JsonConvert.DeserializeObject(jsonString);

            // Access the values
            string memberid = jsonData.memberid;
            string password = jsonData.password;

            LoginPage loginPage = new LoginPage(driverWait);
            loginPage.EnterCredentials(memberid,password);
            loginPage.Login();
            Thread.Sleep(3000);
            HomePage homePage = new HomePage(driverWait);
            homePage.VerifyHomePage();
            homePage.ClickShopByCategories();
            PLPage plpage = new PLPage(driverWait);
            plpage.VerifyProdcutsPage();
            CartPage cartPage = new CartPage(driver);
            cartPage.ClearCart();
        }

        [TearDown]
        public void TearDown()
        {
            driver.driver.Quit();
        }
    }
}
