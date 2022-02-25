using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class CreateNewProjectPage : BasePage
    {
        private static readonly By ProjectNameSelector = By.Id("inputTitle");
        private static readonly By ProjectCodeSelector = By.Id("inputCode");
        private static readonly By ProjectDescriptionSelector = By.Id("inputDescription");
        private static readonly By ErrorCodeMessage = By.ClassName("alert-message");
        private static readonly By CreateProjectButtonSelector = By.CssSelector(".btn.btn-primary");

        public CreateNewProjectPage() : base(By.XPath($"//h1[text()='New Project']"))
        {
        }

        public static void SetProjectName(string projectName) =>
            new Input(ProjectNameSelector).ClearAndSendKey(projectName);

        public static void SetProjectCode(string projectCode) =>
            new Input(ProjectCodeSelector).ClearAndSendKey(projectCode);

        public static void SetProjectDescription(string projectDescription) =>
            new Input(ProjectDescriptionSelector).ClearAndSendKey(projectDescription);

        public static void CreateProjectButtonClick() =>
            new Button(CreateProjectButtonSelector).Click();

        public static string GetErrorCodeMessage() =>
            new Text(ErrorCodeMessage).GetText();
    }
}
