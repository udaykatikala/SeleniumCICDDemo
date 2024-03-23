using OpenQA.Selenium;
using SeleniumCourse.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCourse.Pages
{
    public class HomePage(DriverWait driver)
    {
        /*private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }*/


        IWebElement ddFlex => driver.FindElement(By.XPath("//div[contains(@class,'flex-dropdown')]//span[text()='Flex']"));
        IWebElement shopByCategories => driver.FindElement(By.XPath("//span[text()='Shop by categories']"));
        IWebElement lnkAllProducts => driver.FindElement(By.XPath("(//a[text()='All Products'])[1]"));

       
        public void VerifyHomePage()
        {
            Thread.Sleep(5000);
            Assert.IsTrue(ddFlex.Displayed);
        }

        public void ClickShopByCategories()
        {
            Thread.Sleep(5000);
            shopByCategories.Click();
            lnkAllProducts.Click();
           
        }

    }
}
