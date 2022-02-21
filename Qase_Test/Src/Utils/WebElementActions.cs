using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;

namespace Qase_Test.Utils
{
    public static class WebElementActions
    {
        public static IWebElement GetElement(By locator) =>
            BrowsersService.GetWaiters.WaitForVisibility(locator);

        public static IWebElement GetElementWithoutWaiters(By locator) =>
            BrowsersService.GetDriver.FindElement(locator);
    }
}
