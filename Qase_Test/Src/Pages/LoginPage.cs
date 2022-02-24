using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages
{
    public class LoginPage : BasePage
    {
        private const string EmailLabel = "Email";
        private const string PasswordLabel = "Password";
        private readonly By _loginButtonSelector = By.Id("btnLogin");

        public LoginPage() : base(By.Id("Symbols"))
        {
        }

        public static void SetEmail(string email) =>
            new Input(EmailLabel).ClearAndSendKey(email);

        public static void SetPassword(string password) =>
            new Input(PasswordLabel).ClearAndSendKey(password);

        public void LoginButtonClick() =>
            BaseElement.GetElement(_loginButtonSelector).Click();
    }
}
