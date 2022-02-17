using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _loginButtonSelector = By.Id("btnLogin");
        private readonly By _emailSelector = By.Id("inputEmail");
        private readonly By _passwordSelector = By.Id("inputPassword");
        private static readonly By LogInPageSelector = By.Id("Symbols");

        private Input EmailInput => new Input(_emailSelector);

        private Input PasswordInput => new Input(_passwordSelector);

        public LoginPage() : base(LogInPageSelector)
        {
        }

        public void SetEmail(string email) =>
            EmailInput.ClearAndSendKey(email);

        public void SetPassword(string password) =>
            PasswordInput.ClearAndSendKey(password);

        public void LoginButtonClick() =>
            WebElementActions.GetElement(_loginButtonSelector).Click();
    }
}
