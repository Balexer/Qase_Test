using NUnit.Allure.Attributes;
using Qase_Test.Models;
using Qase_Test.Pages;

namespace Qase_Test.Steps.UiSteps
{
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps()
        {
            _loginPage = new LoginPage();
        }

        [AllureStep("Try to LogIn")]
        public void Login(User user)
        {
            _loginPage.SetEmail(user.Email);
            _loginPage.SetPassword(user.Password);
            _loginPage.LoginButtonClick();
        }

        [AllureStep("Check is page opened")]
        public bool IsPageOpened() =>
            _loginPage.WaitForOpen();
    }
}
