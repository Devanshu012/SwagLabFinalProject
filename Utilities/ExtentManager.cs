using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SwagLabFinalProject.Utilities
{
    public class ExtentManager
    {
        private static ExtentReports _extent;
        private static string reportPath;

        public static ExtentReports GetExtent()
        {
            if (_extent == null)
            {
                string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                string reportFolder = Path.Combine(projectRoot, "ExtentReport");
                reportPath = Path.Combine(reportFolder, "TestReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
                Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

                // Declare and initialize the reporter here
                var htmlReporter = new ExtentSparkReporter(reportPath);
                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }

            return _extent;
        }
        public static void Flush()
        {
            _extent.Flush();
        }
    }
}
