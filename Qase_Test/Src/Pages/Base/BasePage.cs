using OpenQA.Selenium;
using Qase_Test.Core;

namespace Qase_Test.Pages.Base
{
    public abstract class BasePage
    {
        protected readonly BrowsersService BrowsersService;
        private readonly By _locator;

        protected BasePage(BrowsersService browsersService, By locator)
        {
            BrowsersService = browsersService;
            _locator = locator;
        }

        protected bool WaitForOpen()
        {
            try
            {
                var isOpened = BrowsersService.GetWaiters().WaitForVisibility(_locator).Displayed;
                return isOpened;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
