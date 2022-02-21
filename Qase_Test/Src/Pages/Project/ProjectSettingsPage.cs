using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class ProjectSettingsPage : BasePage
    {
        private static readonly By ProjectSettingsPageSelector = By.XPath("//h1[text()='Settings']");
        private readonly By _deleteProjectButtonSelector = By.CssSelector(".btn-cancel");
        private const string ProjectDescriptionLabel = "Description";

        public ProjectSettingsPage() : base(ProjectSettingsPageSelector)
        {
        }

        public void ClickDeleteProject()
        {
            try
            {
                BrowsersService.GetDriver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException)
            {
                WebElementActions.GetElement(_deleteProjectButtonSelector).Click();
            }
        }

        public static string GetProjectDescription() =>
            new Input(ProjectDescriptionLabel).GetText();
    }
}
