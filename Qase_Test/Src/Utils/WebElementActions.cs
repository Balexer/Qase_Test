using NLog;
using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Wrappers;

namespace Qase_Test.Utils
{
    public static class WebElementActions
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void JsClick(this By locator)
        {
            var executor = (IJavaScriptExecutor) BrowsersService.Driver;
            executor.ExecuteScript("arguments[0].click();", BaseElement.GetElement(locator));
        }

        public static bool IsDisplayed(this By locator)
        {
            try
            {
                return BaseElement.GetElement(locator).Displayed;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Info(ex.Message);
                return false;
            }
        }
    }
}
