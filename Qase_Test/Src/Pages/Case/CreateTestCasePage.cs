using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;

namespace Qase_Test.Pages.Case
{
    public class CreateTestCasePage : BasePage

    {
        private static readonly By CreateTestCasePageSelector = By.XPath("//h1[text()='Create test case']");
        private readonly By _titleSelector = By.Id("title");
        private readonly By _saveSelector = By.Id("save-case");
        private const string TextPropertySelector =
            "//label[text()='replace']/..//div[@class='ProseMirror toastui-editor-contents']";
        private const string PropertyButtonSelector = "//label[text()='replace']/../div";
        private const string DropDownPropertySelector = "//div[text()='replace']";

        public CreateTestCasePage() : base(CreateTestCasePageSelector)
        {
        }

        public void SetTitle(string testCaseName) =>
            WebElementActions.GetElement(_titleSelector).SendKeys(testCaseName);

        public void SaveTestCase() =>
            WebElementActions.GetElement(_saveSelector).Click();

        public static void SetDropDownProperty(string value, string propertyName)
        {
            WebElementActions.GetElement(ReplaceLocator(PropertyButtonSelector, propertyName)).Click();
            WebElementActions.GetElement(ReplaceLocator(DropDownPropertySelector, value)).Click();
        }

        public static void SetTextProperty(string value, string propertyName) =>
            WebElementActions.GetElement(ReplaceLocator(TextPropertySelector, propertyName)).SendKeys(value);
    }
}
