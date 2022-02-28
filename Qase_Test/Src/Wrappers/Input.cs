using OpenQA.Selenium;

namespace Qase_Test.Wrappers
{
    public class Input : BaseElement
    {
        public Input(By locator) : base(locator)
        {
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
