using OpenQA.Selenium;
using Qase_Test.BaseEntity;
using Qase_Test.Core;

namespace Qase_Test.Pages
{
    public class LoginPage : BasePage

    {
        private readonly By _inputLoginSelector = By.Id("inputEmail");
        private readonly By _inputPasswordSelector = By.Id("inputPassword");
        private readonly By _loginButtonSelector = By.Id("btnLogin");
        private readonly string errorMessageSelector = "form-control-feedback";


        public LoginPage(BrowsersService browsersService) : base(browsersService)
        {
        }

        public override bool IsPageOpened()
        {
            return BrowsersService.GetWaiters().WaitForVisibility(By.Id("btnLogin")).Displayed;
        }
        public void SetEmail(string email)
        {
            BrowsersService.GetWaiters().WaitForVisibility(_inputLoginSelector).SendKeys(email);
        }

        public void SetPassword(string password)
        {
            BrowsersService.GetWaiters().WaitForVisibility(_inputPasswordSelector).SendKeys(password);
        }

        public void LoginButtonClick()
        {
            BrowsersService.GetWaiters().WaitForVisibility(_loginButtonSelector).Click();
        }

        public string GetErrorMessage()
        {
            return BrowsersService.GetWaiters().WaitForVisibility(By.ClassName(errorMessageSelector)).Text;
        }

    }
}