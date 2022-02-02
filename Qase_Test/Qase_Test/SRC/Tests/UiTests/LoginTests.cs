using NUnit.Framework;
using Qase_Test.BaseEntity;
using Qase_Test.Core;
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
            
            Assert.AreEqual(BrowsersService.GetDriver().Url, ReadProperties.HomeUrl);
        }
        
        [Test]
        public void LoginWithWrongPasswordTest()
        {
            var loginSteps = new LoginSteps(BrowsersService);
            loginSteps.Login(ReadProperties.Email, ReadProperties.WrongPassword);
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual("These credentials do not match our records.", loginSteps.GetErrorMessage());
                Assert.True(loginSteps.IsPageOpened());
            });
        }
    }
}