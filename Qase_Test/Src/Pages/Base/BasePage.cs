using NLog;
using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;

namespace Qase_Test.Pages.Base
{
    public abstract class BasePage
    {
        private readonly By _locator;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected BasePage(By locator)
        {
            _locator = locator;
        }

        public bool WaitForOpen()
        {
            try
            {
                return BrowsersService.GetWaiters.WaitForVisibility(_locator).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                Logger.Info(ex);
                return false;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Info(ex);
                return false;
            }
        }
    }
}
