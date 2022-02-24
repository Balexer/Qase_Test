using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class CreateNewProjectPage : BasePage
    {
        private const string ProjectNameLabel = "Title";
        private const string ProjectCodeLabel = "Code";
        private const string ProjectDescriptionLabel = "Description";
        private static readonly By ErrorCodeMessage = By.ClassName("alert-message");
        private readonly By _createProjectButtonSelector = By.CssSelector(".btn.btn-primary");

        public CreateNewProjectPage() : base(By.XPath($"//h1[text()='New Project']"))
        {
        }

        public static void SetProjectName(string projectName) =>
            new Input(ProjectNameLabel).ClearAndSendKey(projectName);

        public static void SetProjectCode(string projectCode) =>
            new Input(ProjectCodeLabel).ClearAndSendKey(projectCode);

        public static void SetProjectDescription(string projectDescription) =>
            new Input(ProjectDescriptionLabel).ClearAndSendKey(projectDescription);

        public void CreateProjectButtonClick() =>
            BaseElement.GetElement(_createProjectButtonSelector).Click();

        public static string GetErrorCodeMessage() =>
            BaseElement.GetElement(ErrorCodeMessage).Text;
    }
}
