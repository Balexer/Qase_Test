using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;

namespace Qase_Test.Pages.Project
{
    public class DeleteProjectPage : BasePage
    {
        private static readonly By DeleteProjectPageSelector = By.XPath("//h3[contains(text(),'Are you sure')]");
        private readonly By _deleteProjectButtonSelector = By.CssSelector(".btn-cancel");

        public DeleteProjectPage() : base(DeleteProjectPageSelector)
        {
        }

        public void ConfirmDelete() =>
            WebElementActions.GetElement(_deleteProjectButtonSelector).Click();
    }
}
