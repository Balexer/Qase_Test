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
        private readonly By _projectNameSelector = By.Id("inputTitle");
        private readonly By _projectCodeSelector = By.Id("inputCode");
        private readonly By _projectDescriptionSelector = By.Id("inputDescription");

        private Input ProjectNameInput => new(_projectNameSelector);

        private Input ProjectCodeInput => new(_projectCodeSelector);

        private Input ProjectDescriptionInput => new(_projectDescriptionSelector);

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
