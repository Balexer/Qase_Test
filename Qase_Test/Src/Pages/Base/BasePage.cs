using NLog;
using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;

namespace Qase_Test.Pages.Base
{
    public abstract class BasePage
    {
        private readonly By _locator;
        private const string ErrorMessageSelector = "form-control-feedback";
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

        protected static string ReplaceLocator(string locator, string elementName)
        {
            var newLocator = locator.Replace("replace", elementName);
            return newLocator;
        }

        protected static IWebElement GetElement(By locator) =>
            BrowsersService.GetWaiters.WaitForVisibility(locator);

        public static string GetErrorMessage() =>
            GetElement(By.ClassName(ErrorMessageSelector)).Text;

        protected static void Input(string locator, string value)
        {
            var element = GetElement(By.Id($"input{locator}"));
            element.Clear();
            element.SendKeys(value);
        }
    }
}
