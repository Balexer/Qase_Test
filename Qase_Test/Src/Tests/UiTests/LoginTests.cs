using NUnit.Framework;
using Qase_Test.Core;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Fakers;
using Qase_Test.Models;
using Qase_Test.Pages;
using Qase_Test.Steps.UiSteps;
using Qase_Test.Tests.Base;

namespace Qase_Test.Tests.UiTests
{
    public class LoginTests : BaseTest
    {
        private LoginSteps _loginSteps;
        private HomePage _homePage;

        [SetUp]
        public void SetUp()
        {
            _loginSteps = new LoginSteps();
            _homePage = new HomePage();
        }

        [Test]
        public void LoginTest()
        {
            _loginSteps.Login(Settings.GetUser());

            Assert.AreEqual(BrowsersService.GetDriver.Url, ReadProperties.HomeUrl, "HomePage didn't open");
            Assert.True(_homePage.WaitForOpen(), "HomePage didn't open");
        }

        [Test]
        public void LoginWithWrongPasswordTest()
        {
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
