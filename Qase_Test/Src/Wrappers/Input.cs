using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Utils;

namespace Qase_Test.Wrappers
{
    public static class Input
    {
        public static void CleanInputValue(string label, string value)
        {
            ClearField(label);
            SendKeys(label, value);
        }

        private static void ClearField(string label) =>
            WebElementActions.GetElement(By.Id($"input{label}")).Clear();

        private static void SendKeys(string label, string value) =>
            WebElementActions.GetElement(By.Id($"input{label}")).SendKeys(value);
    }
}
