using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using Qase_Test.Fakers;
using Qase_Test.Models;
using Qase_Test.Pages;
using Qase_Test.Pages.Base;
using Qase_Test.Pages.Project;
using Qase_Test.Steps.UiSteps;
using Qase_Test.Tests.Base;

namespace Qase_Test.Tests.UiTests
{
    public class ProjectTests : BaseTest
    {
        private ProjectSteps _projectSteps;
        private ProjectPage _projectPage;
        private Project _project;

        [SetUp]
        public void SetUp()
        {
            _projectSteps = new ProjectSteps();
            _projectPage = new ProjectPage();

            _project = ProjectFaker.GetFakeProject();
            LoginSteps.Login(User);
        }

        [Test, Description("Creating a project")]
        [AllureSubSuite("Project")]
        public void CreateProjectTest()
        {
            _projectSteps.CreateNewProject(_project);

            _project.ProjectName.Should().Be(ProjectPage.GetTitle());
            _projectPage.MoveToProjectSettingsPage();
            _project.ProjectDescription.Should().Be(ProjectSettingsPage.GetProjectDescription());
        }

        [Test, Description("Deletion project from Home page")]
        [AllureSubSuite("Project")]
        public void DeleteProjectFromHomePageTest()
        {
            _projectSteps.CreateNewProject(_project);

            _projectSteps.DeleteProjectFromHomePage(_project);

            HomePage.FindProjectByName(_project.ProjectName).Should().BeFalse();
        }

        [Test, Description("Deletion project from Project page")]
        [AllureSubSuite("Project")]
        public void DeleteProjectFromProjectPageTest()
        {
            _projectSteps.CreateNewProject(_project);

            _projectSteps.DeleteProjectFromProjectPage();

            HomePage.FindProjectByName(_project.ProjectName).Should().BeFalse();
        }

        [Test, Description("Create project with existing code")]
        [AllureSubSuite("Project")]
        public void CreateProjectWithExistingCodeTest()
        {
            _projectSteps.CreateNewProject(_project);
            _projectPage.MoveToHomePage();

            _projectSteps.CreateNewProject(_project);

            CreateNewProjectPage.GetErrorCodeMessage().Should().Be("Project with the same code already exists.");
        }

        [Test, Description("Create project with wrong code")]
        [AllureSubSuite("Project")]
        public void CreateProjectWithWrongCodeTest()
        {
            var project = ProjectFaker.GetFakeProject();
            project.ProjectCode = project.WrongProjectCode;

            _projectSteps.CreateNewProject(project);

            BasePage.GetErrorMessage().Should().Be("The code must be at least 2 characters.");
        }
    }
}
