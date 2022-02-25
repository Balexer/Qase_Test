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
        private static readonly By SettingsSelector = By.XPath("//a[@data-bs-original-title='Settings']");
        private static readonly By ProjectsButtonSelector = By.XPath("//a[@aria-label='Projects']");
        private static readonly By CreateCaseButtonSelector = By.Id("create-case-button");
        private static Button WindowModeSelector => new(By.XPath("//i[@class='far fa-window-restore']"));
        private static Button QuiteWindowModeSelector => new(By.XPath("//i[@class='fal fa-times']"));

        public ProjectPage() : base(By.XPath("//span[text()='Suites']"))
        {
        }

        public static string GetTitle() =>
            new Text(TitleSelector).GetText();

        public static void MoveToProjectSettingsPage() =>
            new Button(SettingsSelector).Click();

        public static void MoveToHomePage() =>
            new Button(ProjectsButtonSelector).Click();

        public static void CreateTestCase() =>
            new Button(CreateCaseButtonSelector).Click();

        public static void SelectTestCase(string caseName) =>
            new Button(ReplaceLocator(TestCaseSelector, caseName)).Click();

        public static void ChooseWindowMode() => WindowModeSelector.JsClick();

        public static void QuiteWindowMode() => QuiteWindowModeSelector.JsClick();

        public static string GetTestCaseTextProperty(string propertyName) =>
            new Text(ReplaceLocator(TextPropertySelector, propertyName)).GetText();

        public static string GetTestCaseDropDownProperty(string propertyName) =>
            new Text(ReplaceLocator(DropDownPropertySelector, propertyName)).GetText();
    }
}
