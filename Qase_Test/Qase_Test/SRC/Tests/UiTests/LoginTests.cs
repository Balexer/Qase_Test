using NUnit.Framework;
using Qase_Test.BaseEntity;
using Qase_Test.Core;
using Qase_Test.Fakers;
using Qase_Test.Steps.UiSteps;

namespace Qase_Test.Tests.UiTests
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void LoginTest()
        {
            var loginSteps = new LoginSteps(BrowsersService);
            loginSteps.Login(ReadProperties.Email, ReadProperties.Password);

            Assert.AreEqual(BrowsersService.GetDriver().Url, ReadProperties.HomeUrl, "HomePage didn't open");
        }

        [Test]
        public void LoginWithWrongPasswordTest()
        {
            var loginSteps = new LoginSteps(BrowsersService);
            loginSteps.Login(UserFaker.GetFakeUser().Email, UserFaker.GetFakeUser().Password);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("These credentials do not match our records.", loginSteps.GetErrorMessage(),
                    "Error message isn't visible");
                Assert.True(loginSteps.IsPageOpened(), "This is another page");
            });
        }
    }
}
