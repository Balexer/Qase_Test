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
            _projectSteps.CreateNewProject(_project); //just creates a project

            _project.ProjectName.Should().Be(ProjectPage.GetTitle());
            _projectPage.MoveToProjectSettingsPage();
            _project.ProjectDescription.Should().Be(ProjectSettingsPage.GetProjectDescription());
        }

        [Test, Description("Deletion project from Home page")]
        [AllureSubSuite("Project")]
        public void DeleteProjectFromHomePageTest()
        {
            _projectSteps.CreateNewProject(_project); //preconditions

            _projectSteps.DeleteProjectFromHomePage(_project);

            HomePage.FindProjectByName(_project.ProjectName).Should().BeFalse();
        }
        //there are two methods for deleting a project from the HomePage, and from the ProjectPage itself, I check both
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
            _projectSteps.CreateNewProject(_project); //Preconditions: creates a project
            _projectPage.MoveToHomePage();

            _projectSteps.CreateNewProject(_project); //trying to create a project with the same code

            CreateNewProjectPage.GetErrorCodeMessage().Should().Be("Project with the same code already exists.");
        }

        [Test, Description("Create project with wrong code")]
        [AllureSubSuite("Project")]
        public void CreateProjectWithWrongCodeTest()
        {
            var project = ProjectFaker.GetFakeProject();
            project.ProjectCode = project.WrongProjectCode; //a project can be created with a code of at least two characters, I create with one

            _projectSteps.CreateNewProject(project);

            BasePage.GetErrorMessage().Should().Be("The code must be at least 2 characters.");
        }
    }
}
