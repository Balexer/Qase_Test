using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;

namespace Qase_Test.Pages.Project
{
    public class DeleteProjectPage : BasePage
    {
        private static readonly By DeleteProjectPageSelector = By.XPath("//h3[contains(text(),'Are you sure')]");
        private readonly By _deleteProjectButtonSelector = By.CssSelector(".btn-cancel");

        public DeleteProjectPage() : base(DeleteProjectPageSelector)
        {
        }

        private static IWebElement GetElement(By locator) =>
            BrowsersService.GetWaiters.WaitForVisibility(locator);

        public void ConfirmTheDelete() =>
            GetElement(_deleteProjectButtonSelector).Click();
    }
}
