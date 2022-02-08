using NUnit.Allure.Core;
using NUnit.Framework;
using Qase_Test.Core;
using Qase_Test.Core.Browser.Service;

namespace Qase_Test.Tests.Base
{
    [AllureNUnit]
    public abstract class BaseTest
    {
        [SetUp]
        public void OpenPage()
        {
            BrowsersService.SetupBrowser();
            BrowsersService.SetupWaiters();
            BrowsersService.GetDriver.Navigate().GoToUrl(ReadProperties.Url);
        }

        [TearDown]
        public void ClosePage()
        {
            BrowsersService.GetDriver.Quit();
        }
    }
}
