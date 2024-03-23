using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumCourse.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCourse.Drivers
{
    public class Driver
    {
        private readonly TestSettings testSettings;
        public IWebDriver driver {  get; set; }
        public Driver(TestSettings testSettings)
        {
            this.testSettings = testSettings;
            driver = GetWebDriver();
            driver.Navigate().GoToUrl(testSettings.applicationURL);
        }



        private IWebDriver GetWebDriver()
        {

            switch (testSettings.browserType)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.Edge:
                    driver = new EdgeDriver();
                    break;
            }


            return driver;
        }
    }
}
public enum BrowserType
{
    Chrome,
    Firefox,
    Edge
}