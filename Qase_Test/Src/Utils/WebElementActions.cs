using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;

namespace Qase_Test.Utils
{
    public static class WebElementActions
    {
        public static IWebElement GetElement(By locator) =>
            BrowsersService.GetWaiters.WaitForVisibility(locator);

        public static void JsClick(By locator)
        {
            var executor = (IJavaScriptExecutor) BrowsersService.GetDriver;
            executor.ExecuteScript("arguments[0].click();", GetElement(locator));
        }
    }
}
