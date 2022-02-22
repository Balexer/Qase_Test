using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using Qase_Test.Constants;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Fakers;
using Qase_Test.Pages;
using Qase_Test.Pages.Base;
using Qase_Test.Tests.Base;

namespace Qase_Test.Tests.UiTests
{
    public class LoginTests : BaseTest
    {
        private HomePage _homePage;

        [SetUp]
        public void SetUp()
        {
            _homePage = new HomePage();
        }

        [Test, Description("Log in with correct credentials")]
        [AllureSubSuite("Log In")]
        [AllureTms("AA-30")]
        public void LoginTest()
        {
            LoginSteps.Login(User);

            using (new AssertionScope())
            {
                BrowsersService.GetDriver.Url.Should().Be(UriConstants.HomeUri);
                _homePage.WaitForOpen().Should().BeTrue();
            }
        }

        [Test, Description("Log in with wrong credentials")]
        [AllureSubSuite("Log In")]
        public void LoginWithWrongCreedsTest()
        {
            LoginSteps.Login(UserFaker.GetFakeUser());

            using (new AssertionScope())
            {
                BasePage.GetErrorMessage().Should().Be("These credentials do not match our records.");
                LoginSteps.IsPageOpened().Should().BeTrue();
            }
        }
    }
}
