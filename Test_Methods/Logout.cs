using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SwagLabFinalProject.ObjectRepositories;

namespace SwagLabFinalProject.Test_Methods
{
    public class Logout : LoginAndLogoutPage
    {
        public Logout(IWebDriver driver):base(driver)
        {

        }
        public void ClickMenuButton()
        {
            MenuButton.Click();
        }
        public void ClickLogoutButton()
        {
            Thread.Sleep(1000);
            LogoutButton.Click();
        }
        public bool VerifyLogout()
        {
            bool result = LoginButton.Displayed;
            return result;
        }

    }
}
