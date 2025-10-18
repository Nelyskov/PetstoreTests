using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using Allure.Commons;
using Allure.NUnit;

namespace PetstoreTests.Tests
{
    [AllureNUnit]
    public class BaseTest
    {
        protected static ExtentReports _extent;
        protected ExtentTest _test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var projectDir = TestContext.CurrentContext.WorkDirectory;
            var reportPath = Path.Combine(projectDir, "Reports");
            Directory.CreateDirectory(reportPath);

            var htmlReporter = new ExtentSparkReporter("Reports/ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void SetUp()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        
        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
                _test.Fail(TestContext.CurrentContext.Result.Message);
            else
                _test.Pass("Test passed");

            _extent.Flush();
        }
    }
}