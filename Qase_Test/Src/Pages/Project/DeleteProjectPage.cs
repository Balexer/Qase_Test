using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class DeleteProjectPage : BasePage
    {
        private static readonly By DeleteProjectButtonSelector = By.CssSelector(".btn-cancel");

        public DeleteProjectPage() : base(By.XPath("//h3[contains(text(),'Are you sure')]"))
        {
        }

        public static void ConfirmDelete() =>
            new Button(DeleteProjectButtonSelector).Click();
    }
}
