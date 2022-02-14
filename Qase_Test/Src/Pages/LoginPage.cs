using OpenQA.Selenium;
using Qase_Test.Pages.Base;

namespace Qase_Test.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _loginButtonSelector = By.Id("btnLogin");
        private static readonly By LogInPageSelector = By.Id("Symbols");

        public LoginPage() : base(LogInPageSelector)
        {
        }

        public static void SetEmail(string email) =>
            Wrappers.Wrappers.Input("Email", email);

        public static void SetPassword(string password) =>
            Wrappers.Wrappers.Input("Password", password);

        public void LoginButtonClick() =>
            GetElement(_loginButtonSelector).Click();
    }
}
