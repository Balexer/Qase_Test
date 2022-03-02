using System.Net;
using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Qase_Test.Fakers;
using Qase_Test.Models;
using Qase_Test.Steps.ApiSteps;

namespace Qase_Test.Tests.ApiTests
{
    [AllureNUnit]
    [AllureTag("Functional")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Bachurin")]
    [AllureSuite("API")]
    public class TestCaseApiTests
    {
        private Project _project;
        private TestCase _testCase;

        [SetUp]
        public void SetUp()
        {
            _testCase = TestDataGeneratorService.GetFakeCase();
            _project = TestDataGeneratorService.GetFakeProject();

            ProjectApiHelper.CreateProject(_project);
        }

        [TearDown]
        public void TearDown() =>
            ProjectApiHelper.DeleteProject(_project);

        [Test, Description("Test case creation check")]
        [AllureSubSuite("TestCaseApi")]
        public void CreateTestCaseTest() =>
            TestCaseApiHelper.CreateTestCase(_project, _testCase).Should().Be(HttpStatusCode.OK);

        [Test, Description("Test case title check")]
        [AllureSubSuite("TestCaseApi")]
        public void GetTestCaseTest()
        {
            TestCaseApiHelper.CreateTestCase(_project, _testCase).Should().Be(HttpStatusCode.OK);
            TestCaseApiHelper.GetTestCaseTitle(_project).Should().Be(_testCase.CaseTitle);
        }

        [Test, Description("Test case deletion check")]
        [AllureSubSuite("TestCaseApi")]
        public void DeleteTestCaseTest()
        {
            TestCaseApiHelper.CreateTestCase(_project, _testCase).Should().Be(HttpStatusCode.OK);
            TestCaseApiHelper.DeleteTestCase(_project).Should().Be(HttpStatusCode.OK);
        }

        [Test, Description("Try to create test case without title")]
        [AllureSubSuite("TestCaseApi")]
        public void CreateTestCaseTestWithoutTitle()
        {
            _testCase.CaseTitle = "";
            TestCaseApiHelper.CreateTestCase(_project, _testCase).Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}
