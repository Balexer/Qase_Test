using NLog;
using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Utils;

namespace Qase_Test.Pages.Base
{
    public abstract class BasePage
    {
        private readonly By _locator;
        private const string ErrorMessageSelector = "form-control-feedback";
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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

        protected static By ReplaceLocator(string locator, string elementName) =>
            By.XPath(locator.Replace("replace", elementName));

        public static string GetErrorMessage() =>
            WebElementActions.GetElement(By.ClassName(ErrorMessageSelector)).Text;
    }
}
