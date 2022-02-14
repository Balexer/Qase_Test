using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;

namespace Qase_Test.Wrappers
{
    public static class Wrappers
    {
        public static void Input(string locator, string value)
        {
            var element = BrowsersService.GetWaiters.WaitForVisibility(By.Id($"input{locator}"));
            element.Clear();
            element.SendKeys(value);
        }
    }
}
