using OpenQA.Selenium;
using Qase_Test.Core;
using Qase_Test.Pages.Base;


namespace Qase_Test.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _inputLoginSelector = By.Id("inputEmail");
        private readonly By _inputPasswordSelector = By.Id("inputPassword");
        private readonly By _loginButtonSelector = By.Id("btnLogin");
        private const string ErrorMessageSelector = "form-control-feedback";
        private static readonly By LogInPageSelector = By.Id("Symbols");

        public LoginPage(BrowsersService browsersService) : base(browsersService, LogInPageSelector)
        {
        }

        public bool IsPageOpened() => WaitForOpen();

        private IWebElement GetElement(By locator) =>
            BrowsersService.GetWaiters().WaitForVisibility(locator);

        public void SetEmail(string email) =>
            GetElement(_inputLoginSelector).SendKeys(email);

        public void SetPassword(string password) =>
            GetElement(_inputPasswordSelector).SendKeys(password);

        public void LoginButtonClick() =>
            GetElement(_loginButtonSelector).Click();

        public string GetErrorMessage() =>
            GetElement(By.ClassName(ErrorMessageSelector)).Text;
    }
}
