using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenQA.Selenium;
using SwagLabFinalProject.Test_Methods;

namespace SwagLabFinalProject.Test_Cases
{
    public class PurchaseCase:Purchase
    {
        public PurchaseCase(IWebDriver driver) : base(driver)
        {

        }
        public void Purchase(string first_name, string last_name, string pinCode)
        {
            string f_name= first_name;
            string l_name= last_name;
            string pin = pinCode;
            SauceLabBackpack();
            SauceLabBikeLight();
            AddToCartButton();
            Checkout();
            YourInformation(f_name, l_name, pin);
            Finish();

        }
    }
}
