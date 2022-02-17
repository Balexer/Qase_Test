using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Utils;

namespace Qase_Test.Wrappers
{
    public static class Input
    {
        public static void ClearAndSendKey(string label, string value)
        {
            Clear(label);
            SendKeys(label, value);
        }

        public static string GetText(string label) =>
            GetInputElement(label).Text;

        private static void Clear(string label) =>
            GetInputElement(label).Clear();

        private static void SendKeys(string label, string value) =>
            GetInputElement(label).SendKeys(value);

        private static IWebElement GetInputElement(string label) =>
            WebElementActions.GetElement(By.Id($"input{label}"));
    }
}
