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

        public CreateNewProjectPage() : base(CreateProjectPageSelector)
        {
        }

        public static void SetProjectName(string projectName) =>
            new Input(ProjectNameLabel).ClearAndSendKey(projectName);

        public static void SetProjectCode(string projectCode) =>
            new Input(ProjectCodeLabel).ClearAndSendKey(projectCode);

        public static void SetProjectDescription(string projectDescription) =>
            new Input(ProjectDescriptionLabel).ClearAndSendKey(projectDescription);

        public void CreateProjectButtonClick() =>
            WebElementActions.GetElement(_createProjectButtonSelector).Click();

        public static string GetErrorCodeMessage() =>
            WebElementActions.GetElement(ErrorCodeMessage).Text;
    }
}
