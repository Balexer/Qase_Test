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
        private string _token;

        [SetUp]
        public void SetUp()
        {
            _project = TestDataGeneratorService.GetFakeProject();
            _token = UserSettings.Token;
        }

        [Test, Description("Project сreation check")]
        [AllureSubSuite("ProjectApi")]
        public void CreateProjectTest()
        {
            ProjectApiSteps.CreateProject(_project, _token).Should().Be(HttpStatusCode.OK);
        }

        [Test, Description("Delete project")]
        [AllureSubSuite("ProjectApi")]
        public void DeleteProjectTest()
        {
            ProjectApiSteps.CreateProject(_project, _token);

            ProjectApiSteps.DeleteProject(_project, _token).Should().Be(HttpStatusCode.OK);
        }

        [Test, Description("Create project by member")]
        [AllureSubSuite("ProjectApi")]
        public void CreateProjectByMemberTest()
        {
            ProjectApiSteps.CreateProject(_project, UserSettings.MemberToken).Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test, Description("Create Project with wrong code")]
        [AllureSubSuite("ProjectApi")]
        public void CreateProjectWithWrongCode()
        {
            var project = TestDataGeneratorService.GetFakeProject();
            project.ProjectCode = project.WrongProjectCode;

            ProjectApiSteps.CreateProject(project, _token).Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Test, Description("Creation project with existing code")]
        [AllureSubSuite("ProjectApi")]
        public void CreateProjectWithExistingCodeTest()
        {
            ProjectApiSteps.CreateProject(_project, _token).Should().Be(HttpStatusCode.OK);

            ProjectApiSteps.CreateProject(_project, _token).Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}
