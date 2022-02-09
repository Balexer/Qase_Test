using OpenQA.Selenium;
using Qase_Test.Pages.Base;

namespace Qase_Test.Pages
{
    public class HomePage : BasePage
    {
        private static readonly By HomePageSelector = By.XPath("//h1[text()='Projects']");

        public HomePage() : base(HomePageSelector)
        {
        }
    }
}
