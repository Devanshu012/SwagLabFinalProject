using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SwagLabFinalProject.Test_Methods;

namespace SwagLabFinalProject.Test_Cases
{
    public class FaildAttemptToLogin:LoginWithWrongCreds
    {
        public FaildAttemptToLogin(IWebDriver driver):base(driver)
        {
            
        }
        public void LoginWithWrongPassword(string username, string password)
        {
            InputData(username, password);
            ClickOnLoginButton();
            Assert.IsTrue(VerifyLoggedIn());
        }
    }
}
