using NUnit.Framework;
using Qase_Test.Core;
using Qase_Test.Fakers;
using Qase_Test.Models;
using Qase_Test.Steps.UiSteps;
using Qase_Test.Tests.Base;

namespace Qase_Test.Tests.UiTests
{
    public class LoginTests : BaseTest
    {
        private LoginSteps _loginSteps;
        
        [SetUp]
        public void SetUp()
        {
            _loginSteps = new LoginSteps(BrowsersService);
        }
        
        [Test]
        public void LoginTest()
        {
            // var loginSteps = new LoginSteps(BrowsersService);
            _loginSteps.Login(Settings.GetUser());

            Assert.AreEqual(BrowsersService.GetDriver().Url, ReadProperties.HomeUrl, "HomePage didn't open");
        }

        [Test]
        public void LoginWithWrongPasswordTest()
        {
            // var loginSteps = new LoginSteps(BrowsersService);
            _loginSteps.Login(UserFaker.GetFakeUser());

            Assert.Multiple(() =>
            {
                Assert.AreEqual("These credentials do not match our records.", _loginSteps.GetErrorMessage(),
                    "Error message isn't visible");
                Assert.True(_loginSteps.IsPageOpened(), "This is another page");
            });
        }
    }
}
