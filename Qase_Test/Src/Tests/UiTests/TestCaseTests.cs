using FluentAssertions;
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
        private User _user;
        private TestCase _testCase;

        [SetUp]
        public void SetUp()
        {
            LoginSteps = new LoginSteps();
            _projectSteps = new ProjectSteps();
            _testCasesSteps = new TestCasesSteps();
            _projectPage = new ProjectPage();
            _createTestCasePage = new CreateTestCasePage();
            _user = new User();

            _testCase = TestCaseFaker.GetFakeCase();
            _project = ProjectFaker.GetFakeProject();
            LoginSteps.Login(_user);
            _projectSteps.CreateNewProject(_project);
            _projectPage.MoveToHomePage();
        }

        [TearDown]
        public void TearDown()
        {
            _projectSteps.DeleteProjectFromProjectPage();
        }

        [Test]
        public void CreateDefaultTestCaseTest()
        {
            var defaultTestCase = new TestCase();
            _testCasesSteps.CreateTestCaseInProject(_project, defaultTestCase);

            _testCasesSteps.GetTestCase(defaultTestCase).Should().BeEquivalentTo(defaultTestCase);
        }

        [Test]
        public void CreateTestCase()
        {
            _testCasesSteps.CreateTestCaseInProject(_project, _testCase);

            _testCasesSteps.GetTestCase(_testCase).Should().BeEquivalentTo(_testCase);
        }

        [Test]
        public void CreateTestCaseWithoutName()
        {
            _testCase.CaseTitle = "";
            _testCasesSteps.CreateTestCaseInProject(_project, _testCase);

            _createTestCasePage.WaitForOpen().Should().BeTrue();
        }
    }
}
