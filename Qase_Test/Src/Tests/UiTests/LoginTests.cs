using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
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
        [AllureSubSuite("Log In")]
        [AllureStep("LogIn with correct credentials")]
        [AllureLink("Test Case", "https://app.qase.io/project/AA?previewMode=side&view=1&suite=3&case=30")]
        public void LoginTest()
        {
            _loginSteps.Login(ModelsSettings.GetUser());

            using (new AssertionScope())
            {
                BrowsersService.GetDriver.Url.Should().Be(ReadProperties.HomeUrl);
                _homePage.WaitForOpen().Should().BeTrue();
            }
        }

        [Test]
        [AllureSubSuite("Log In")]
        [AllureStep("LogIn with incorrect credentials")]
        public void LoginWithWrongCreedsTest()
        {
            _loginSteps.Login(UserFaker.GetFakeUser());

            using (new AssertionScope())
            {
                _loginSteps.GetErrorMessage().Should().Be("These credentials do not match our records.");
                _loginSteps.IsPageOpened().Should().BeTrue();
            }
        }
    }
}
