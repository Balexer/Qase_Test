using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class ProjectSettingsPage : BasePage
    {
        private static readonly By ProjectSettingsPageSelector = By.XPath("//h1[text()='Settings']");
        private readonly By _deleteProjectButtonSelector = By.CssSelector(".btn-cancel");
        private readonly By _projectDescriptionSelector = By.Id("inputDescription");

        private Input ProjectDescriptionInput => new Input(_projectDescriptionSelector);

        public ProjectSettingsPage() : base(ProjectSettingsPageSelector)
        {
        }

        public void ClickDeleteProject() =>
            WebElementActions.GetElement(_deleteProjectButtonSelector).Click();

        public string GetProjectDescription() =>
            ProjectDescriptionInput.GetText();
    }
}
