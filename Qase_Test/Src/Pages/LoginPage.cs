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

        public LoginPage() : base(LogInPageSelector)
        {
        }

        public static void SetEmail(string email) =>
            new Input(EmailLabel).ClearAndSendKey(email);

        public static void SetPassword(string password) =>
            new Input(PasswordLabel).ClearAndSendKey(password);

        public void LoginButtonClick() =>
            WebElementActions.GetElement(_loginButtonSelector).Click();
    }
}
