using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;

namespace Qase_Test.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _inputLoginSelector = By.Id("inputEmail");
        private readonly By _inputPasswordSelector = By.Id("inputPassword");
        private readonly By _loginButtonSelector = By.Id("btnLogin");
        private static readonly By LogInPageSelector = By.Id("Symbols");

        public LoginPage() : base(LogInPageSelector)
        {
        }

        public void SetEmail(string email) =>
            Input("Email", email);

        public void SetPassword(string password) =>
            Input("Password", password);

        public void LoginButtonClick() =>
            GetElement(_loginButtonSelector).Click();
    }
}
