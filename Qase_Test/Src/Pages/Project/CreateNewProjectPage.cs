using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class CreateNewProjectPage : BasePage
    {
        private static readonly By ErrorCodeMessage = By.ClassName("alert-message");
        private static readonly By CreateProjectPageSelector = By.XPath("//h1[text()='New Project']");
        private readonly By _createProjectButtonSelector = By.CssSelector(".btn.btn-primary");
        private const string ProjectNameLabel = "Title";
        private const string ProjectCodeLabel = "Code";
        private const string ProjectDescriptionLabel = "Description";

        private Input ProjectNameInput => new(ProjectNameLabel);

        private Input ProjectCodeInput => new(ProjectCodeLabel);

        private Input ProjectDescriptionInput => new(ProjectDescriptionLabel);

        public CreateNewProjectPage() : base(CreateProjectPageSelector)
        {
        }

        public void SetProjectName(string projectName) =>
            ProjectNameInput.ClearAndSendKey(projectName);

        public void SetProjectCode(string projectCode) =>
            ProjectCodeInput.ClearAndSendKey(projectCode);

        public void SetProjectDescription(string projectDescription) =>
            ProjectDescriptionInput.ClearAndSendKey(projectDescription);

        public void CreateProjectButtonClick() =>
            WebElementActions.GetElement(_createProjectButtonSelector).Click();

        public static string GetErrorCodeMessage() =>
            WebElementActions.GetElement(ErrorCodeMessage).Text;
    }
}
