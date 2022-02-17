using NLog;
using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Utils;

namespace Qase_Test.Pages.Base
{
    public abstract class BasePage
    {
        private readonly By _locator;
        private static readonly By ErrorMessageSelector = By.ClassName("form-control-feedback");
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
                Logger.Info(ex.Message);
                return false;
            }
        }

        protected static By ReplaceLocator(string locator, string elementName) =>
            By.XPath(locator.Replace("replace", elementName));

        public static string GetErrorMessage() =>
            WebElementActions.GetElement(ErrorMessageSelector).Text;
    }
}
