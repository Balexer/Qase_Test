using Qase_Test.BaseEntity;
using Qase_Test.Core;
using Qase_Test.Pages;

namespace Qase_Test.Steps.UiSteps
{
    public class LoginSteps : BaseStep
    {
        public LoginSteps(BrowsersService browsersService) : base(browsersService)
        {
        }

        public void Login(string email, string password)
        {
            var loginPage = new LoginPage(browsersService);
            loginPage.SetEmail(email);
            loginPage.SetPassword(password);
            loginPage.LoginButtonClick();
        }

        public string GetErrorMessage()
        {
            var loginPage = new LoginPage(browsersService);
            return loginPage.GetErrorMessage();
        }
        
        public bool IsPageOpened()
        {
            var loginPage = new LoginPage(browsersService);
            return loginPage.IsPageOpened();
        }
    }
}