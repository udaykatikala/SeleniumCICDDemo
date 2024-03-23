using OpenQA.Selenium;
using SeleniumCourse.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCourse.Pages
{
    public class PLPage(DriverWait driver )
    {
       /* private readonly IWebDriver driver;

        public PLPage(IWebDriver driver)
        {
            this.driver = driver;
        }*/

        IWebElement imgProducts => driver.FindElement(By.XPath("(//div[@class='product-img'])[1]"));

        public void VerifyProdcutsPage()
        {
            Thread.Sleep(3000);
            Assert.IsTrue(imgProducts.Displayed);
        }
        
    }
}
