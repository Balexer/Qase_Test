using NUnit.Allure.Attributes;
using Qase_Test.Models;
using Qase_Test.Pages;
using Qase_Test.Pages.Project;

namespace Qase_Test.Steps.UiSteps
{
    public class ProjectSteps
    {
        private static CreateNewProjectPage CreateNewProjectPage => new();

        private static DeleteProjectPage DeleteProjectPage => new();

        private static ProjectPage ProjectPage => new();

        private static ProjectSettingsPage ProjectSettingsPage => new();

        private static HomePage HomePage => new();

        [AllureStep("Try to Create a project")]
        public static void CreateNewProject(Project project)
        {
            HomePage.CreateNewProject();
            CreateNewProjectPage.SetProjectName(project.ProjectName);
            CreateNewProjectPage.SetProjectCode(project.ProjectCode);
            CreateNewProjectPage.SetProjectDescription(project.ProjectDescription);
            CreateNewProjectPage.CreateProjectButtonClick();
        }

        [AllureStep("Deletion project from project page")]
        public static void DeleteProjectFromProjectPage()
        {
            ProjectPage.MoveToProjectSettingsPage();
            ProjectSettingsPage.ClickDeleteProject();
            DeleteProjectPage.ConfirmDelete();
        }

        [AllureStep("Deletion project from home page")]
        public static void DeleteProjectFromHomePage(Project project)
        {
            ProjectPage.MoveToHomePage();
            HomePage.OpenProjectDropdownMenu(project.ProjectName);
            HomePage.ClickDropdownMenuDelete();
            DeleteProjectPage.ConfirmDelete();
        }
    }
}
