using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Wrappers;

namespace Qase_Test.Utils
{
    public static class WebElementActions
    {
        public static void JsClick(this BaseElement element)
        {
            var executor = (IJavaScriptExecutor) BrowsersService.Driver;
            executor.ExecuteScript("arguments[0].click();", element.Element);
        }
    }
}
