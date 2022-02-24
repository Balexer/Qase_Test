using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages.Case
{
    public class CreateTestCasePage : BasePage
    {
        private const string LabelSelector = "//label[text()='replace']/..";
        private const string DropDownPropertySelector = "//div[text()='replace']";
        private readonly By _titleSelector = By.Id("title");
        private readonly By _saveSelector = By.Id("save-case");
        private readonly string _textPropertySelector =
            $"{LabelSelector}//div[@class='ProseMirror toastui-editor-contents']";
        private readonly string _propertyButtonSelector = $"{LabelSelector}/div";

        public CreateTestCasePage() : base(By.XPath($"//h1[text()='Create test case']"))
        {
        }

        public void SetTitle(string testCaseName) =>
            BaseElement.GetElement(_titleSelector).SendKeys(testCaseName);

        public void SaveTestCase() =>
            BaseElement.GetElement(_saveSelector).Click();

        public void SetDropDownProperty(string value, string propertyName)
        {
            BaseElement.GetElement(ReplaceLocator(_propertyButtonSelector, propertyName)).Click();
            BaseElement.GetElement(ReplaceLocator(DropDownPropertySelector, value)).Click();
        }

        public void SetTextProperty(string value, string propertyName) =>
            BaseElement.GetElement(ReplaceLocator(_textPropertySelector, propertyName)).SendKeys(value);
    }
}
