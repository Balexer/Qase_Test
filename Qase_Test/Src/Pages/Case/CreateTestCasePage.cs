using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Case
{
    public class CreateTestCasePage : BasePage

    {
        private readonly By _titleSelector = By.Id("title");
        private readonly By _saveSelector = By.Id("save-case");
        private const string LabelSelector = "//label[text()='replace']/..";
        private readonly string _textPropertySelector =
            $"{LabelSelector}//div[@class='ProseMirror toastui-editor-contents']";
        private readonly string _propertyButtonSelector = $"{LabelSelector}/div";
        private const string DropDownPropertySelector = "//div[text()='replace']";
        private const string CreateTestCaseTitleText = "Create test case";

        public CreateTestCasePage() : base(new Title(CreateTestCaseTitleText).GetLocator())
        {
        }

        public void SetTitle(string testCaseName) =>
            WebElementActions.GetElement(_titleSelector).SendKeys(testCaseName);

        public void SaveTestCase() =>
            WebElementActions.GetElement(_saveSelector).Click();

        public void SetDropDownProperty(string value, string propertyName)
        {
            WebElementActions.GetElement(ReplaceLocator(_propertyButtonSelector, propertyName)).Click();
            WebElementActions.GetElement(ReplaceLocator(DropDownPropertySelector, value)).Click();
        }

        public void SetTextProperty(string value, string propertyName) =>
            WebElementActions.GetElement(ReplaceLocator(_textPropertySelector, propertyName)).SendKeys(value);
    }
}
