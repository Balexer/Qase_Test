using OpenQA.Selenium;
using Qase_Test.Pages.Base;

namespace Qase_Test.Pages.Project
{
    public class ProjectSettingsPage : BasePage
    {
        private static readonly By ProjectSettingsPageSelector = By.XPath("//h1[text()='Settings']");
        private readonly By _deleteProjectButtonSelector = By.CssSelector(".btn-cancel");
        private readonly By _descriptionSelector = By.Id("inputDescription");

        public ProjectSettingsPage() : base(ProjectSettingsPageSelector)
        {
        }

        public void ClickDeleteProject() =>
            GetElement(_deleteProjectButtonSelector).Click();

        public string GetProjectDescription() =>
            GetElement(_descriptionSelector).Text;
    }
}
