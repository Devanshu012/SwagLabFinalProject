using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SwagLabFinalProject.ObjectRepositories;

namespace SwagLabFinalProject.Test_Methods
{
    public class Purchase : ToPurchase
    {
        public Purchase(IWebDriver driver) : base(driver)
        {

        }

        public void SauceLabBackpack()
        {
            labBackpack.Click();
        }

        public void SauceLabBikeLight()
        {
            redTshirt.Click();
        }
        public void AddToCartButton()
        {
            cart.Click();
        }
        public void Checkout()
        {
            checkout.Click();
        }
        public void YourInformation(string f_name, string l_name, string postal_code)
        {
            firstName.SendKeys(f_name);
            lastName.SendKeys(l_name);
            postalCode.SendKeys(postal_code);
            Continue.Click();
        }
        public void Finish()
        {
            finish.Click();
        }

    }
}
