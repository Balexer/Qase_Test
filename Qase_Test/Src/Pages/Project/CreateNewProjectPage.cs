using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;

namespace Qase_Test.Pages.Project
{
    public class CreateNewProjectPage : BasePage
    {
        private const string ErrorCodeMessage = "alert-message";
        private const string ErrorMessage = "form-control-feedback";
        private static readonly By CreateProjectPageSelector = By.XPath("//h1[text()='New Project']");
        private readonly By _projectNameSelector = By.Id("inputTitle");
        private readonly By _projectCodeSelector = By.Id("inputCode");
        private readonly By _projectDescriptionSelector = By.Id("inputDescription");
        private readonly By _createProjectButtonSelector = By.CssSelector(".btn.btn-primary");

        public CreateNewProjectPage() : base(CreateProjectPageSelector)
        {
        }

        private static IWebElement GetElement(By locator) =>
            BrowsersService.GetWaiters.WaitForVisibility(locator);

        public void SetProjectName(string projectName) =>
            GetElement(_projectNameSelector).SendKeys(projectName);

        public void SetProjectCode(string projectCode)
        {
            var projectCodeSelector = GetElement(_projectCodeSelector);
            projectCodeSelector.Clear();
            projectCodeSelector.SendKeys(projectCode);
        }

        public void SetProjectDiscription(string projectDiscription) =>
            GetElement(_projectDescriptionSelector).SendKeys(projectDiscription);

        public void CreateProjectButtonClick() =>
            GetElement(_createProjectButtonSelector).Click();

        public static string GetErrorCodeMessage() =>
            GetElement(By.ClassName(ErrorCodeMessage)).Text;

        public static string GetErrorMessage() =>
            GetElement(By.ClassName(ErrorMessage)).Text;
    }
}
