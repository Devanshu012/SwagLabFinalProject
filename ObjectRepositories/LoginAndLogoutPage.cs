using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SwagLabFinalProject.ObjectRepositories
{
    public class LoginAndLogoutPage
    {
        public IWebDriver driver;

        public LoginAndLogoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Login
        public IWebElement UsernameField => driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordField => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        public IWebElement cartIcon => driver.FindElement(By.XPath("//a[@class=\"shopping_cart_link\"]"));

        // Logout
        public IWebElement MenuButton => driver.FindElement(By.Id("react-burger-menu-btn"));
        public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[@id='logout_sidebar_link']"));
    }
}
