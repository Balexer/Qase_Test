using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Utils;

namespace Qase_Test.Wrappers
{
    public class Input : BaseElement
    {
        public Input(string label)
        {
            Element = GetElement(By.Id($"input{label}"));
        }

        public void ClearAndSendKey(string value)
        {
            Clear();
            SendKeys(value);
        }

        public string GetText() =>
            Element.Text;

        private void Clear() =>
            Element.Clear();

        private void SendKeys(string value) =>
            Element.SendKeys(value);
    }
}
