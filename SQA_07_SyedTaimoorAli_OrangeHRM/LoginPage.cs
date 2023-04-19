using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace SQA_07_SyedTaimoorAli_OrangeHRM
{
    public class LoginPage : BasePage
    {       
        public static void Login(string url, string user, string pass, string gotourl)
        {
            OpenUrl(url);
            Write(By.Name("username"), user);
            Write(By.Name("password"), pass);
            Click(By.CssSelector("#app > div.orangehrm-login-layout > div > div.orangehrm-login-container > div > div.orangehrm-login-slot > div.orangehrm-login-form > form > div.oxd-form-actions.orangehrm-login-action > button"));
            Goto(gotourl);
        }
    }
}
