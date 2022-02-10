using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;

namespace Qase_Test.Pages.Project
{
    public class ProjectSettingsPage : BasePage
    {
        private static readonly By ProjectSettingsPageSelector = By.XPath("//h1[text()='Settings']");
        private readonly By _deleteProjectButtonSelector = By.CssSelector(".btn-cancel");

        public ProjectSettingsPage() : base(ProjectSettingsPageSelector)
        {
        }

        private static IWebElement GetElement(By locator) =>
            BrowsersService.GetWaiters.WaitForVisibility(locator);

        public void ClickDeleteProject() =>
            GetElement(_deleteProjectButtonSelector).Click();
    }
}
