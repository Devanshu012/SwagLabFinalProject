using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagLabFinalProject.Utilities;

namespace SwagLabFinalProject.Setup
{
    public class Base
    {
        protected ExtentReports extent;
        //[ThreadStatic]
        //protected ExtentTest test;
        protected static ThreadLocal<ExtentTest> test = new ThreadLocal<ExtentTest>();

        [ThreadStatic] // Ensure each test has its own WebDriver instance.
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = ExtentManager.GetExtent();
        }

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        }

        [TearDown]
        public void TearDown()
        {
            // To add the screenshot in the extent report
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;

            if (testStatus == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, testName);
                test.Value?.Log(Status.Fail, "Test failed. Screenshot below:");
                test.Value?.AddScreenCaptureFromPath(screenshotPath);
            }

            
            Thread.Sleep(2000);
            driver.Dispose();
            driver = null;
            test.Value = null;
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.Flush();
            test.Dispose();
            EmailReport.SendEmail();
        }

        public void Retry(Action retryAction, int maxRetries = 3)
        {
            int attempt = 0;
            while (attempt < maxRetries)
            {
                attempt++;
                test.Value?.Info($"Retrying attempt {attempt} of {maxRetries}");

                // Quit the WebDriver and dispose of it
                if (driver != null)
                {
                    driver.Quit();
                    driver = null;
                }

                Thread.Sleep(2000); // Adding a small delay before reinitializing WebDriver

                // Re-initialize the WebDriver
                Setup();

                retryAction(); // Retry the test action

                test.Value?.Pass($"Retry succeeded on attempt {attempt}");
                break; // If successful, exit the loop
            }
        }

    }

}
