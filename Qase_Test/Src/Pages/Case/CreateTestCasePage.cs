using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Case
{
    public class CreateTestCasePage : BasePage
    {
        private const string LabelSelector = "//label[text()='replace']/..";
        private const string DropDownPropertySelector = "//div[text()='replace']";
        private static readonly By TitleSelector = By.Id("title");
        private static readonly By SaveSelector = By.Id("save-case");
        private static readonly string TextPropertySelector =
            $"{LabelSelector}//div[@class='ProseMirror toastui-editor-contents']";
        private static readonly string PropertyButtonSelector = $"{LabelSelector}/div";

        public CreateTestCasePage() : base(By.XPath("//h1[text()='Create test case']"))
        {
        }

        public static void SetTitle(string testCaseName) =>
            new Input(TitleSelector).ClearAndSendKey(testCaseName);

        public static void SaveTestCase() =>
            new Button(SaveSelector).Click();

        public static void SetDropDownProperty(string value, string propertyName)
        {
            new Button(ReplaceLocator(PropertyButtonSelector, propertyName)).Click();
            new Button(ReplaceLocator(DropDownPropertySelector, value)).Click();
        }

        public static void SetTextProperty(string value, string propertyName) =>
            new Input(ReplaceLocator(TextPropertySelector, propertyName)).ClearAndSendKey(value);
    }
}
