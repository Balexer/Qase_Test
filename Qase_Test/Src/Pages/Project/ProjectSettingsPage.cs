using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class ProjectSettingsPage : BasePage
    {
        private readonly By _deleteProjectButtonSelector = By.CssSelector(".btn-cancel");
        private const string ProjectDescriptionLabel = "Description";
        private static readonly By ProjectSettingsTitleText = By.XPath($"//h1[text()='Settings']");

        public ProjectSettingsPage() : base(ProjectSettingsTitleText)
        {
        }

        public void ClickDeleteProject()
        {
            try
            {
                BrowsersService.GetDriver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException ex)
            {
                Logger.Error(ex.Message);
                WebElementActions.GetElement(_deleteProjectButtonSelector).Click();
            }
        }

        public static string GetProjectDescription() =>
            new Input(ProjectDescriptionLabel).GetText();
    }
}
