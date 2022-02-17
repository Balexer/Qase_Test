using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Utils;

namespace Qase_Test.Wrappers
{
    public class Input
    {
        private IWebElement _element;

        public Input(By locator)
        {
            _element = WebElementActions.GetElement(locator);
        }

        public void ClearAndSendKey(string value)
        {
            Clear();
            SendKeys(value);
        }

        public string GetText() =>
            _element.Text;

        private void Clear() =>
            _element.Clear();

        private void SendKeys(string value) =>
            _element.SendKeys(value);
    }
}
