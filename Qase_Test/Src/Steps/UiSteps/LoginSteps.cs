using NUnit.Allure.Attributes;
using Qase_Test.Models;
using Qase_Test.Pages;

namespace Qase_Test.Steps.UiSteps
{
    public class LoginSteps
    {
        private static LoginPage LoginPage => new();

        [AllureStep("Try to LogIn")]
        public static void Login(User user)
        {
            LoginPage.SetEmail(user.Email);
            LoginPage.SetPassword(user.Password);
            LoginPage.LoginButtonClick();
        }

        [AllureStep("Check is page opened")]
        public static bool IsPageOpened() =>
            LoginPage.WaitForOpen();
    }
}
