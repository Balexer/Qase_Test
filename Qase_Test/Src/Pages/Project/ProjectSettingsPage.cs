using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class ProjectSettingsPage : BasePage
    {
        private static readonly By ProjectDescriptionSelector = By.Id("inputDescription");
        private static readonly By DeleteProjectButtonSelector = By.CssSelector(".btn-cancel");

        public ProjectSettingsPage() : base(By.XPath($"//h1[text()='Settings']"))
        {
        }

        public static void ClickDeleteProject()
        {
            try
            {
                BrowsersService.Driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException ex)
            {
                Logger.Error(ex.Message);
                new Button(DeleteProjectButtonSelector).Click();
            }
        }

        public static string GetProjectDescription() =>
            new Input(ProjectDescriptionSelector).GetText();
    }
}
