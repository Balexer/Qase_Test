using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Project
{
    public class ProjectPage : BasePage
    {
        private const string TextPropertySelector = "//h3[text()='replace']/..//p";
        private const string DropDownPropertySelector = "//span[text()='replace']/..//div//div";
        private const string TestCaseSelector = "//span[text()='replace']/ancestor::tr";
        private static readonly By TitleSelector = By.XPath("//p[@class='header']");
        private readonly By _settingsSelector = By.XPath("//a[@data-bs-original-title='Settings']");
        private readonly By _projectsButtonSelector = By.XPath("//a[@aria-label='Projects']");
        private readonly By _createCaseButtonSelector = By.Id("create-case-button");
        private readonly By _windowModeSelector = By.XPath("//i[@class='far fa-window-restore']");
        private readonly By _quiteWindowModeSelector = By.XPath("//i[@class='fal fa-times']");

        public ProjectPage() : base(By.XPath("//span[text()='Suites']"))
        {
        }

        public static string GetTitle() =>
            BaseElement.GetElement(TitleSelector).Text;

        public void MoveToProjectSettingsPage() =>
            BaseElement.GetElement(_settingsSelector).Click();

        public void MoveToHomePage() =>
            BaseElement.GetElement(_projectsButtonSelector).Click();

        public void CreateTestCase() =>
            BaseElement.GetElement(_createCaseButtonSelector).Click();

        public static void SelectTestCase(string caseName) =>
            BaseElement.GetElement(ReplaceLocator(TestCaseSelector, caseName)).Click();

        public void ChooseWindowMode() =>
            _windowModeSelector.JsClick();

        public void QuiteWindowMode() =>
            _quiteWindowModeSelector.JsClick();

        public static string GetTestCaseTextProperty(string propertyName) =>
            BaseElement.GetElement(ReplaceLocator(TextPropertySelector, propertyName)).Text;

        public static string GetTestCaseDropDownProperty(string propertyName) =>
            BaseElement.GetElement(ReplaceLocator(DropDownPropertySelector, propertyName)).Text;
    }
}
