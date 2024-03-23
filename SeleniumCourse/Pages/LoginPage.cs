using OpenQA.Selenium;
using SeleniumCourse.Drivers;
using SeleniumCourse.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCourse.Pages
{
    public class LoginPage(DriverWait driver )
    {
        IWebElement inpMemberid => driver.FindElement(By.Id("loginField_memberId"));
        IWebElement inpPassword => driver.FindElement(By.Id("loginField_loginPassword"));
        IWebElement btnLogin => driver.FindElement(By.XPath("(//button[contains(text(),'Login')])[1]"));

        public void EnterCredentials(string memberid, string password)
        {
            inpMemberid.SendKeys(memberid);
            inpPassword.SendKeys(password);
        }
        public void Login()
        {
            btnLogin.Click();
        }
    }
}
