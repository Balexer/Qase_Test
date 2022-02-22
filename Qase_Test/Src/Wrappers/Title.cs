using OpenQA.Selenium;

namespace Qase_Test.Wrappers
{
    public class Title
    {
        private readonly string _element;

        public Title(string titleText)
        {
            _element = $"//h1[text()='{titleText}']";
        }

        public By GetLocator()
        {
            return By.XPath(_element);
        }
    }
}
