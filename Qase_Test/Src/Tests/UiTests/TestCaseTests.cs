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
        private ProjectSteps _projectSteps;
        private TestCasesSteps _testCasesSteps;
        private CreateTestCasePage _createTestCasePage;
        private ProjectPage _projectPage;
        private Project _project;
        private TestCase _testCase;

        [SetUp]
        public void SetUp()
        {
            _projectSteps = new ProjectSteps();
            _testCasesSteps = new TestCasesSteps();
            _projectPage = new ProjectPage();
            _createTestCasePage = new CreateTestCasePage();

            _testCase = TestCaseFaker.GetFakeCase();
            _project = ProjectFaker.GetFakeProject();
            LoginSteps.Login(User);
            _projectSteps.CreateNewProject(_project);
            _projectPage.MoveToHomePage();
        }

        [TearDown]
        public void TearDown()
        {
            _projectSteps.DeleteProjectFromProjectPage();
        }

        [Test, Description("Creating a test case only with required fields, the rest are default")]
        [AllureSubSuite("TestCase")]
        public void CreateTestCaseWithRequiredFields()
        {
            var defaultTestCase = new TestCase();
            _testCasesSteps.CreateDefaultTestCase(_project, defaultTestCase); //fills only the title

            _testCasesSteps.GetTestCase(defaultTestCase).Should().BeEquivalentTo(defaultTestCase);
        }

        [Test, Description("Creating a test case with filling in all fields")]
        [AllureSubSuite("TestCase")]
        public void CreateTestCaseWithAllFields()
        {
            _testCasesSteps.CreateTestCaseInProject(_project, _testCase); //fills in all fields of the test case

            _testCasesSteps.GetTestCase(_testCase).Should().BeEquivalentTo(_testCase);
        }

        [Test, Description("Creating a test case without name")]
        [AllureSubSuite("TestCase")]
        public void CreateTestCaseWithoutName()
        {
            _testCase.CaseTitle = "";
            _testCasesSteps.CreateTestCaseInProject(_project, _testCase);

            _createTestCasePage.WaitForOpen().Should().BeTrue();
        }
    }
}
