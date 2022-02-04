using Qase_Test.Core;
using Qase_Test.Pages;
using Qase_Test.Steps.Base;

namespace Qase_Test.Steps.UiSteps
{
    public class LoginSteps : BaseStep
    {
        public LoginSteps(BrowsersService browsersService) : base(browsersService)
        {
        }

        private LoginPage LoginPage() =>
            new(BrowsersService);

        public void Login(string email, string password)
        {
            LoginPage().SetEmail(email);
            LoginPage().SetPassword(password);
            LoginPage().LoginButtonClick();
        }

        public string GetErrorMessage() =>
            LoginPage().GetErrorMessage();


        public bool IsPageOpened() =>
            LoginPage().IsPageOpened();
    }
}
