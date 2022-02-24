using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;

namespace Qase_Test.Wrappers
{
    public abstract class BaseElement
    {
        protected IWebElement Element;

        public static IWebElement GetElement(By locator) =>
            BrowsersService.Waiters.WaitForVisibility(locator);
    }
}
