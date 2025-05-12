using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SwagLabFinalProject.ObjectRepositories
{
    public class YourCartAndInformation
    {
        IWebDriver driver;
        public YourCartAndInformation(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement checkout => driver.FindElement(By.Id("checkout"));

        // Information

        public IWebElement firstName => driver.FindElement(By.Id("first-name"));
        public IWebElement lastName => driver.FindElement(By.Id("last-name"));
        public IWebElement postalCode => driver.FindElement(By.Id("postal-code"));
        public IWebElement Continue => driver.FindElement(By.Id("continue"));

        // Confirm
        public IWebElement finish => driver.FindElement(By.Id("finish"));
    }
}
