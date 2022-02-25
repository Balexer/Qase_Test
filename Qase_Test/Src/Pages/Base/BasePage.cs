using NLog;
using OpenQA.Selenium;
using Qase_Test.Wrappers;

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

        public bool WaitForOpen() => new Text(_locator).IsDisplayed();

        protected static By ReplaceLocator(string locator, string elementName) =>
            By.XPath(locator.Replace("replace", elementName));

        public static string GetErrorMessage() =>
            new Text(ErrorMessageSelector).GetText();
    }
}
