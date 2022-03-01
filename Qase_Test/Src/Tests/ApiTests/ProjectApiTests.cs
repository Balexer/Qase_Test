using System.Net;
using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using Qase_Test.Core;
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
    public class ProjectApiTests
    {
        private Project _project;
        private readonly string _memberToken = UserSettings.MemberToken;

        [SetUp]
        public void SetUp() =>
            _project = TestDataGeneratorService.GetFakeProject();

        [Test, Description("Project сreation check")]
        [AllureSubSuite("ProjectApi")]
        public void CreateProjectTest() =>
            ProjectApiHelper.CreateProject(_project).Should().Be(HttpStatusCode.OK);

        [Test, Description("Delete project")]
        [AllureSubSuite("ProjectApi")]
        public void DeleteProjectTest()
        {
            ProjectApiHelper.CreateProject(_project);
            ProjectApiHelper.DeleteProject(_project).Should().Be(HttpStatusCode.OK);
        }

        [Test, Description("Create project by member")]
        [AllureSubSuite("ProjectApi")]
        public void CreateProjectByMemberTest() =>
            ProjectApiHelper.CreateProject(_project, _memberToken).Should().Be(HttpStatusCode.Forbidden);

        [Test, Description("Create Project with wrong code")]
        [AllureSubSuite("ProjectApi")]
        public void CreateProjectWithWrongCode()
        {
            var project = TestDataGeneratorService.GetFakeProject();
            project.ProjectCode = project.WrongProjectCode;

            ProjectApiHelper.CreateProject(project).Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Test, Description("Creation project with existing code")]
        [AllureSubSuite("ProjectApi")]
        public void CreateProjectWithExistingCodeTest()
        {
            ProjectApiHelper.CreateProject(_project).Should().Be(HttpStatusCode.OK);
            ProjectApiHelper.CreateProject(_project).Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}
