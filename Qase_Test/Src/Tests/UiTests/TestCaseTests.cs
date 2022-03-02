using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using Qase_Test.Fakers;
using Qase_Test.Models;
using Qase_Test.Pages.Case;
using Qase_Test.Pages.Project;
using Qase_Test.Steps.UiSteps;
using Qase_Test.Tests.Base;

namespace Qase_Test.Tests.UiTests
{
    public class TestCaseTests : BaseTest
    {
        private Project _project;
        private TestCase _testCase;

        private static CreateTestCasePage CreateTestCasePage => new();

        [SetUp]
        public void SetUp()
        {
            _testCase = TestDataGeneratorService.GetFakeCase();
            _project = TestDataGeneratorService.GetFakeProject();
            LoginSteps.Login(User);
            ProjectSteps.CreateNewProject(_project);
            ProjectPage.MoveToHomePage();
        }

        [TearDown]
        public void TearDown() =>
            ProjectSteps.DeleteProjectFromProjectPage();

        [Test, Description("Creating a test case only with required fields, the rest are default")]
        [AllureSubSuite("TestCase")]
        public void CreateTestCaseWithRequiredFields()
        {
            var defaultTestCase = new TestCase();
            TestCasesSteps.CreateDefaultTestCase(_project, defaultTestCase);

            TestCasesSteps.GetTestCase(defaultTestCase).Should().BeEquivalentTo(defaultTestCase);
        }

        [Test, Description("Creating a test case with filling in all fields")]
        [AllureSubSuite("TestCase")]
        public void CreateTestCaseWithAllFields()
        {
            TestCasesSteps.CreateTestCaseInProject(_project, _testCase);

            TestCasesSteps.GetTestCase(_testCase).Should().BeEquivalentTo(_testCase);
        }

        [Test, Description("Creating a test case without name")]
        [AllureSubSuite("TestCase")]
        public void CreateTestCaseWithoutName()
        {
            _testCase.CaseTitle = "";
            TestCasesSteps.CreateTestCaseInProject(_project, _testCase);

            CreateTestCasePage.WaitForOpen().Should().BeTrue();
        }
    }
}
