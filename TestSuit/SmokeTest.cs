using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using SwagLabFinalProject.Authentication;
using SwagLabFinalProject.Setup;
using SwagLabFinalProject.Test_Cases;
using SwagLabFinalProject.TestCases;
using SwagLabFinalProject.Utilities;

namespace SwagLabFinalProject.TestSuit
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SmokeTest:Base
    {
        DataDriven data = DataDriven.LoadFromJson();

        [Test, Order(1)]
        public void Test_1_Login()
        {
            test.Value = extent.CreateTest("Test_1_Login"); // Initialize test

            try
            {
                test.Value.Log(Status.Pass, "Login Test Started.");
                var login = new LoginCase(driver);
                login.Log(data.Username, data.Password);
                test.Value.Log(Status.Pass, "Login Test Ended.");
            }
            catch (Exception ex)
            {
                test.Value.Log(Status.Fail, "Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(2)]
        public void Test_2_Logout()
        {
            test.Value = extent.CreateTest("Test_2_Logout"); // Initialize test

            try
            {
                test.Value.Log(Status.Pass, "Logout Test Started.");
                var login = new LoginCase(driver);
                login.Log(data.Username, data.Password);
                var logout = new LogoutCase(driver);
                logout.Logout();
                test.Value.Log(Status.Pass, "Logout Test Ended.");
            }
            catch (Exception ex)
            {
                test.Value.Log(Status.Fail, "Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(3)]
        public void Test_3_Purchase()
        {
            test.Value = extent.CreateTest("Test_3_Purchase"); // Initialize test

            try
            {
                test.Value.Log(Status.Pass, "Purchase Test Started.");
                var login = new LoginCase(driver);
                login.Log(data.Username, data.Password);
                var purchase = new PurchaseCase(driver);
                purchase.Purchase("Devanshu", "Singh", "811312");
                test.Value.Log(Status.Pass, "Purchase Test Ended.");
            }
            catch (Exception ex)
            {
                test.Value.Log(Status.Fail, "Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(4)]
        public void Test_4_FailedAttempedToLogin()
        {
            test.Value = extent.CreateTest("Test_4_LoginWithWrongCreds"); // Initialize test

            try
            {
                test.Value.Log(Status.Pass, "LoginWithWrongCreds Test Started.");
                var loginFailed = new FaildAttemptToLogin(driver);
                loginFailed.LoginWithWrongPassword(data.Username, data.WrongPassword);
                test.Value.Log(Status.Pass, "LoginWithWrongCreds Test Started.");
            }
            catch (Exception ex)
            {
                Retry(() =>
                {
                    var loginFailed = new FaildAttemptToLogin(driver);
                    loginFailed.LoginWithWrongPassword(data.Username, data.WrongPassword);
                }, maxRetries: 3);

                test.Value.Log(Status.Fail, "Test failed: " + ex.Message);
                throw;
            }
        }
    }
}
