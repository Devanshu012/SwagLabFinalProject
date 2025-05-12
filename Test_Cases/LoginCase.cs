using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SwagLabFinalProject.Test_Methods;

namespace SwagLabFinalProject.TestCases
{
    public class LoginCase:Login
    {
        public LoginCase(IWebDriver driver):base(driver)
        {

        }
        public void Log(string username, string password)
        {
            InputData(username, password);
            ClickOnLoginButton();
            Assert.IsTrue(VerifyLoggedIn());
        }
    }
}
