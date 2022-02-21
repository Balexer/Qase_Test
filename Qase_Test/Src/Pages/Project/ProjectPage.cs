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
        private readonly By _createCaseButtonSelector = By.Id("create-case-button");
        private const string TestCaseSelector = "//span[text()='replace']/ancestor::tr";
        private readonly By _windowModeSelector = By.XPath("//i[@class='far fa-window-restore']");
        private readonly By _quiteWindowModeSelector = By.XPath("//i[@class='fal fa-times']");
        private const string TextPropertySelector = "//h3[text()='replace']/..//p";
        private const string DropDownPropertySelector = "//span[text()='replace']/..//div//div";
        private readonly By _alertSelector = By.XPath("//div[@role='alert']");

        public ProjectPage() : base(ProjectPageSelector)
        {
        }

        public static string GetTitle() =>
            WebElementActions.GetElement(TitleSelector).Text;

        public void MoveToProjectSettingsPage() =>
            WebElementActions.GetElement(_settingsSelector).Click();

        public void MoveToHomePage() =>
            WebElementActions.GetElement(_projectsButtonSelector).Click();

        public void CreateTestCase() =>
            WebElementActions.GetElement(_createCaseButtonSelector).Click();

        public static void SelectTestCase(string caseName) =>
            WebElementActions.GetElement(ReplaceLocator(TestCaseSelector, caseName)).Click();

        public void ChooseWindowMode()
        {
            while (IsAlertVisible())
            {
            }

            WebElementActions.GetElement(_windowModeSelector).Click();
        }

        public void QuiteWindowMode() =>
            WebElementActions.GetElement(_quiteWindowModeSelector).Click();

        public static string GetTestCaseTextProperty(string propertyName) =>
            WebElementActions.GetElement(ReplaceLocator(TextPropertySelector, propertyName)).Text;

        public static string GetTestCaseDropDownProperty(string propertyName) =>
            WebElementActions.GetElement(ReplaceLocator(DropDownPropertySelector, propertyName)).Text;

        private bool IsAlertVisible()
        {
            try
            {
                return WebElementActions.GetElementWithoutWaiters(_alertSelector).Displayed;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
