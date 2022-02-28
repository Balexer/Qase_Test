using OpenQA.Selenium;

namespace Qase_Test.Wrappers
{
    public class Text : BaseElement
    {
        public Text(By locator) : base(locator)
        {
        }

        public string GetText() =>
            Element.Text;
    }
}
