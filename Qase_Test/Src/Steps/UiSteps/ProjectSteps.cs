using NUnit.Allure.Attributes;
using Qase_Test.Models;
using Qase_Test.Pages;
using Qase_Test.Pages.Project;

namespace Qase_Test.Steps.UiSteps
{
    public class ProjectSteps
    {
        private readonly CreateNewProjectPage _createNewProjectPage;
        private readonly DeleteProjectPage _deleteProjectPage;
        private readonly ProjectPage _projectPage;
        private readonly ProjectSettingsPage _projectSettingsPage;
        private readonly HomePage _homePage;

        public ProjectSteps()
        {
            _createNewProjectPage = new CreateNewProjectPage();
            _deleteProjectPage = new DeleteProjectPage();
            _projectPage = new ProjectPage();
            _projectSettingsPage = new ProjectSettingsPage();
            _homePage = new HomePage();
        }

        [AllureStep("Try to Create a project")]
        public void CreateNewProject(Project project)
        {
            _homePage.CreateNewProject();
            CreateNewProjectPage.SetProjectName(project.ProjectName);
            CreateNewProjectPage.SetProjectCode(project.ProjectCode);
            CreateNewProjectPage.SetProjectDescription(project.ProjectDescription);
            _createNewProjectPage.CreateProjectButtonClick();
        }

        [AllureStep("Deletion project from project page")]
        public void DeleteProjectFromProjectPage()
        {
            _projectPage.MoveToProjectSettingsPage();
            _projectSettingsPage.ClickDeleteProject();
            _deleteProjectPage.ConfirmDelete();
        }

        [AllureStep("Deletion project from home page")]
        public void DeleteProjectFromHomePage(Project project)
        {
            _projectPage.MoveToHomePage();
            _homePage.OpenProjectDropdownMenu(project.ProjectName);
            HomePage.ClickDropdownMenuDelete();
            _deleteProjectPage.ConfirmDelete();
        }
    }
}
