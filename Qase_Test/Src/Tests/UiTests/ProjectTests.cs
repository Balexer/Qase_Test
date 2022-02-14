using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Framework;
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
        private LoginSteps _loginSteps;
        private ProjectSteps _projectSteps;
        private ProjectPage _projectPage;
        private ProjectSettingsPage _projectSettingsPage;

        [SetUp]
        public void SetUp()
        {
            _loginSteps = new LoginSteps();
            _projectSteps = new ProjectSteps();
            _projectPage = new ProjectPage();
            _projectSettingsPage = new ProjectSettingsPage();

            _loginSteps.Login(ModelsSettings.GetUser());
        }

        [Test]
        [AllureSubSuite("Project")]
        public void CreateProjectTest()
        {
            _projectSteps.CreateNewProject(ModelsSettings.GetProject());

            ModelsSettings.GetProject().ProjectName.Should().Be(ProjectPage.GetTitle());
            _projectPage.MoveToProjectSettingsPage();
            ModelsSettings.GetProject().ProjectDescription.Should().Be(_projectSettingsPage.GetProjectDescription());
        }

        [Test]
        [AllureSubSuite("Project")]
        public void DeleteProjectFromProjectMenuTest()
        {
            _projectSteps.CreateNewProject(ModelsSettings.GetProject());

            _projectSteps.DeleteProjectFromHomePage(ModelsSettings.GetProject());

            HomePage.FindProjectByName(ModelsSettings.GetProject().ProjectName).Should().BeFalse();
        }

        [Test]
        [AllureSubSuite("Project")]
        public void DeleteProjectFromProjectPageTest()
        {
            _projectSteps.CreateNewProject(ModelsSettings.GetProject());

            _projectSteps.DeleteProjectFromProjectPage();

            HomePage.FindProjectByName(ModelsSettings.GetProject().ProjectName).Should().BeFalse();
        }

        [Test]
        [AllureSubSuite("Project")]
        public void CreateProjectWithExistingCodeTest()
        {
            _projectSteps.CreateNewProject(ModelsSettings.GetProject());
            _projectPage.MoveToHomePage();

            _projectSteps.CreateNewProject(ModelsSettings.GetProject());

            CreateNewProjectPage.GetErrorCodeMessage().Should().Be("Project with the same code already exists.");
        }

        [Test]
        [AllureSubSuite("Project")]
        public void CreateProjectWithWrongCodeTest()
        {
            _projectSteps.CreateNewProject(ModelsSettings.GetInvalidProject());

            BasePage.GetErrorMessage().Should().Be("The code must be at least 2 characters.");
        }
    }
}
