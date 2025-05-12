using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SwagLabFinalProject.Test_Methods;

namespace SwagLabFinalProject.Test_Cases
{
    public class LogoutCase:Logout
    {
        public LogoutCase(IWebDriver driver) : base(driver)
        {

        }
        public void Logout()
        {
            ClickMenuButton();
            Thread.Sleep(2000);
            ClickLogoutButton();
            Assert.IsTrue(VerifyLogout());
        }
    }
}
