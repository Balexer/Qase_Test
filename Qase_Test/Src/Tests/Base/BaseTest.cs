using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Qase_Test.Core.Browser;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Models;

namespace Qase_Test.Tests.Base
{
    [AllureNUnit]
    [AllureTag("Functional")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Bachurin")]
    [AllureSuite("Smoke")]
    public abstract class BaseTest
    {
        protected static User User => new();

        [SetUp]
        [AllureStep("Open browser, and setup Browser and Waiters")]
        public void OpenPage()
        {
            BrowsersService.SetupBrowser();
            BrowsersService.Driver.Navigate().GoToUrl(BrowserSettings.Url);
        }

        [TearDown]
        [AllureStep("Close browser")]
        public void ClosePage()
        {
            BrowsersService.Driver.Quit();
            BrowsersService.Driver = null;
        }
    }
}
