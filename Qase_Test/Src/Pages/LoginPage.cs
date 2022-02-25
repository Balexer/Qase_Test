using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By EmailSelector = By.Id("inputEmail");
        private static readonly By PasswordSelector = By.Id("inputPassword");
        private static readonly By LoginButtonSelector = By.Id("btnLogin");

        public LoginPage() : base(By.Id("Symbols"))
        {
        }

        public static void SetEmail(string email) =>
            new Input(EmailSelector).ClearAndSendKey(email);

        public static void SetPassword(string password) =>
            new Input(PasswordSelector).ClearAndSendKey(password);

        public static void LoginButtonClick() =>
            new Button(LoginButtonSelector).Click();
    }
}
