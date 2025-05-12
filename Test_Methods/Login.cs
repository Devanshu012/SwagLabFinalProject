using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SwagLabFinalProject.ObjectRepositories;

namespace SwagLabFinalProject.Test_Methods
{
    public class Login : LoginAndLogoutPage
    {
        public Login(IWebDriver driver) : base(driver)
        {

        }
        public void InputData(string username, string password)
        {
            
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
        }
        public void ClickOnLoginButton()
        {
            LoginButton.Submit();
        }
        public bool VerifyLoggedIn()
        {
            bool result = cartIcon.Displayed;

            return result;
        }
    }
}
