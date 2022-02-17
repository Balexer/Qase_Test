using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _loginButtonSelector = By.Id("btnLogin");
        private static readonly By LogInPageSelector = By.Id("Symbols");
        private const string EmailLabel = "Email";
        private const string PasswordLabel = "Password";

        private Input EmailInput => new(EmailLabel);

        private Input PasswordInput => new(PasswordLabel);

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
