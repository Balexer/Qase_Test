using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class CreateNewProjectPage : BasePage
    {
        private const string ErrorCodeMessage = "alert-message";
        private static readonly By CreateProjectPageSelector = By.XPath("//h1[text()='New Project']");
        private readonly By _createProjectButtonSelector = By.CssSelector(".btn.btn-primary");

        public CreateNewProjectPage() : base(CreateProjectPageSelector)
        {
        }

        public static void SetProjectName(string projectName) =>
            Input.InputValue("Title", projectName);

        public static void SetProjectCode(string projectCode) =>
            Input.InputValue("Code", projectCode);

        public static void SetProjectDescription(string projectDescription) =>
            Input.InputValue("Description", projectDescription);

        public void CreateProjectButtonClick() =>
            GetElement(_createProjectButtonSelector).Click();

        public static string GetErrorCodeMessage() =>
            GetElement(By.ClassName(ErrorCodeMessage)).Text;
    }
}
