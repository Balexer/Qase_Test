using OpenQA.Selenium;

namespace Qase_Test.Wrappers
{
    public class Button : BaseElement
    {
        public Button(By locator) : base(locator)
        {
        }

        public void Click()
        {
            Element.Click();
        }
    }
}
