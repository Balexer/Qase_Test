using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class ProjectSettingsPage : BasePage
    {
        private const string ProjectDescriptionLabel = "Description";
        private readonly By _deleteProjectButtonSelector = By.CssSelector(".btn-cancel");

        public ProjectSettingsPage() : base(By.XPath($"//h1[text()='Settings']"))
        {
        }

        public void ClickDeleteProject()
        {
            try
            {
                BrowsersService.Driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException ex)
            {
                Logger.Error(ex.Message);
                BaseElement.GetElement(_deleteProjectButtonSelector).Click();
            }
        }

        public static string GetProjectDescription() =>
            new Input(ProjectDescriptionLabel).GetText();
    }
}
