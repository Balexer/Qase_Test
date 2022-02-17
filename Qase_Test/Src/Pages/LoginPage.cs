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

        public LoginPage() : base(LogInPageSelector)
        {
        }

        public static void SetEmail(string email) =>
            Input.ClearAndSendKey("Email", email);

        public static void SetPassword(string password) =>
            Input.ClearAndSendKey("Password", password);

        public void LoginButtonClick() =>
            WebElementActions.GetElement(_loginButtonSelector).Click();
    }
}
