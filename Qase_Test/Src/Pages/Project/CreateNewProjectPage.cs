using OpenQA.Selenium;
using Qase_Test.Pages.Base;

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
            Wrappers.Wrappers.Input("Title", projectName);

        public static void SetProjectCode(string projectCode) =>
            Wrappers.Wrappers.Input("Code", projectCode);

        public static void SetProjectDescription(string projectDescription) =>
            Wrappers.Wrappers.Input("Description", projectDescription);

        public void CreateProjectButtonClick() =>
            GetElement(_createProjectButtonSelector).Click();

        public static string GetErrorCodeMessage() =>
            GetElement(By.ClassName(ErrorCodeMessage)).Text;
    }
}
