using OpenQA.Selenium;
using SeleniumCourse.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeleniumCourse.Pages
{
    public class CartPage(Driver drive)
    {

        IWebElement chkboxClearCart => drive.driver.FindElement(By.XPath("//input[@name='masterCheckbox']/following-sibling::span"));

        public void ClearCart()
        {
            //chkboxClearCart.Click();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)drive.driver;
            executor.ExecuteScript("arguments[0].click();", chkboxClearCart);

            //different types of checkboxes

            Boolean display = chkboxClearCart.Displayed;
            if(display==true)
            {
                executor.ExecuteScript("arguments[0].click();", chkboxClearCart);
            }
            Boolean enable = chkboxClearCart.Enabled;
            if (enable == true)
            {
                executor.ExecuteScript("arguments[0].click();", chkboxClearCart);
            }
            Boolean select = chkboxClearCart.Selected;
            if (select == false)
            {
                executor.ExecuteScript("arguments[0].click();", chkboxClearCart);
            }

        }
    }
}
