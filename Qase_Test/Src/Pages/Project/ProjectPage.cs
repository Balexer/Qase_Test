using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;

namespace Qase_Test.Pages.Project
{
    public class ProjectPage : BasePage
    {
        private static readonly By TitleSelector = By.XPath("//p[@class='header']");
        private static readonly By ProjectPageSelector = By.XPath("//span[text()='Suites']");
        private readonly By _settingsSelector = By.XPath("//a[@data-bs-original-title='Settings']");
        private readonly By _projectsButtonSelector = By.XPath("//a[@aria-label='Projects']");

        public ProjectPage() : base(ProjectPageSelector)
        {
        }

        public static string GetTitle() =>
            WebElementActions.GetElement(TitleSelector).Text;

        public void MoveToProjectSettingsPage() =>
            WebElementActions.GetElement(_settingsSelector).Click();

        public void MoveToHomePage() =>
            WebElementActions.GetElement(_projectsButtonSelector).Click();
    }
}
