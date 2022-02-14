using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;

namespace Qase_Test.Pages.Project
{
    public class ProjectPage : BasePage
    {
        private const string TitleSelector = "//p[@class='header']";
        private static readonly By ProjectPageSelector = By.XPath("//span[text()='Suites']");
        private readonly By _settingsSelector = By.XPath("//a[@data-bs-original-title='Settings']");
        private readonly By _projectsButtonSelector = By.XPath("//a[@aria-label='Projects']");

        public ProjectPage() : base(ProjectPageSelector)
        {
        }

        public static string GetTitle() =>
            GetElement(By.XPath(TitleSelector)).Text;

        public void MoveToProjectSettingsPage() =>
            GetElement(_settingsSelector).Click();

        public void MoveToHomePage() =>
            GetElement(_projectsButtonSelector).Click();
    }
}
