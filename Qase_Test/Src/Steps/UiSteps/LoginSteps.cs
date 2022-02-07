using Qase_Test.Core;
using Qase_Test.Models;
using Qase_Test.Pages;
using Qase_Test.Steps.Base;

namespace Qase_Test.Steps.UiSteps
{
    public class LoginSteps : BaseStep
    {
        private readonly LoginPage _loginPage;
        public LoginSteps(BrowsersService browsersService)
        {
            _loginPage = new LoginPage(browsersService);
        }

        // private LoginPage LoginPage() =>
        //     new(BrowsersService);

        public void Login(User user)
        {
            _loginPage.SetEmail(user.Email);
            _loginPage.SetPassword(user.Password);
            _loginPage.LoginButtonClick();
        }

        public string GetErrorMessage() =>
            _loginPage.GetErrorMessage();

        public bool IsPageOpened() =>
            _loginPage.IsPageOpened();
    }
}
