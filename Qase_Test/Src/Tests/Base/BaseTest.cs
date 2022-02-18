using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Qase_Test.Core;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Steps.UiSteps;

namespace Qase_Test.Tests.Base
{
    [AllureNUnit]
    [AllureTag("Functional")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Bachurin")]
    [AllureSuite("Smoke")]
    public abstract class BaseTest
    {
        protected LoginSteps LoginSteps;

        [SetUp]
        [AllureStep("Open browser, and setup Browser and Waiters")]
        public void OpenPage()
        {
            BrowsersService.SetupBrowser();
            BrowsersService.SetupWaiters();
            BrowsersService.GetDriver.Navigate().GoToUrl(ReadProperties.Url);
            LoginSteps = new LoginSteps();
        }

        [TearDown]
        [AllureStep("Close browser")]
        public void ClosePage()
        {
            BrowsersService.GetDriver.Quit();
        }
    }
}
