using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;

namespace Qase_Test.Wrappers
{
    public abstract class BaseElement
    {
        private readonly By _by;

        protected BaseElement(By by)
        {
            _by = by;
        }

        private static IWebElement GetElement(By locator) =>
            BrowsersService.Waiters.WaitForVisibility(locator);

        public IWebElement Element => GetElement(_by);

        public bool IsDisplayed()
        {
            try
            {
                return Element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
