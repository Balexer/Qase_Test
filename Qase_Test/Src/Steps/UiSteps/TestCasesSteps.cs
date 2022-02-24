using NUnit.Allure.Attributes;
using Qase_Test.Constants;
using Qase_Test.Models;
using Qase_Test.Pages;
using Qase_Test.Pages.Case;
using Qase_Test.Pages.Project;

namespace Qase_Test.Steps.UiSteps
{
    public class TestCasesSteps
    {
        private static ProjectPage ProjectPage => new();

        private static CreateTestCasePage CreateTestCasePage => new();

        private const string Preconditions = "Preconditions";
        private const string Postconditions = "Postconditions";
        private const string AutomationStatus = "Automation";

        [AllureStep("Create test case in project")]
        public static void CreateTestCaseInProject(Project project, TestCase testCase)
        {
            HomePage.OpenProjectByName(project.ProjectName);
            ProjectPage.CreateTestCase();
            CreateTestCasePage.SetTitle(testCase.CaseTitle);
            CreateTestCasePage.SetTextProperty(testCase.Description, TestCaseConstants.DescriptionProperty);
            CreateTestCasePage.SetTextProperty(testCase.Preconditions, TestCaseConstants.PreconditionsProperty);
            CreateTestCasePage.SetTextProperty(testCase.Postconditions, TestCaseConstants.PostconditionsProperty);
            CreateTestCasePage.SetDropDownProperty(testCase.Severity, TestCaseConstants.SeverityProperty);
            CreateTestCasePage.SetDropDownProperty(testCase.Status, TestCaseConstants.StatusProperty);
            CreateTestCasePage.SetDropDownProperty(testCase.Priority, TestCaseConstants.PriorityProperty);
            CreateTestCasePage.SetDropDownProperty(testCase.Behavior, TestCaseConstants.BehaviorProperty);
            CreateTestCasePage.SetDropDownProperty(testCase.Type, TestCaseConstants.TypeProperty);
            CreateTestCasePage.SetDropDownProperty(testCase.IsFlaky, TestCaseConstants.IsFlakyProperty);
            CreateTestCasePage.SetDropDownProperty(testCase.Layer, TestCaseConstants.LayerProperty);
            CreateTestCasePage.SetDropDownProperty(testCase.Automation, TestCaseConstants.AutomationProperty);
            CreateTestCasePage.SaveTestCase();
        }

        [AllureStep("Create test case with required fields")]
        public static void CreateDefaultTestCase(Project project, TestCase testCase)
        {
            HomePage.OpenProjectByName(project.ProjectName);
            ProjectPage.CreateTestCase();
            CreateTestCasePage.SetTitle(testCase.CaseTitle);
            CreateTestCasePage.SaveTestCase();
        }

        [AllureStep("Get information from test case")]
        public static TestCase GetTestCase(TestCase testCase)
        {
            ProjectPage.SelectTestCase(testCase.CaseTitle);
            ProjectPage.ChooseWindowMode();
            var actualTestCase = new TestCase()
            {
                CaseTitle = testCase.CaseTitle,
                Description = ProjectPage.GetTestCaseTextProperty(TestCaseConstants.DescriptionProperty),
                Preconditions = ProjectPage.GetTestCaseTextProperty(Preconditions),
                Postconditions = ProjectPage.GetTestCaseTextProperty(Postconditions),
                Severity = ProjectPage.GetTestCaseDropDownProperty(TestCaseConstants.SeverityProperty),
                Status = ProjectPage.GetTestCaseDropDownProperty(TestCaseConstants.StatusProperty),
                Priority = ProjectPage.GetTestCaseDropDownProperty(TestCaseConstants.PriorityProperty),
                Behavior = ProjectPage.GetTestCaseDropDownProperty(TestCaseConstants.BehaviorProperty),
                Type = ProjectPage.GetTestCaseDropDownProperty(TestCaseConstants.TypeProperty),
                IsFlaky = ProjectPage.GetTestCaseDropDownProperty(TestCaseConstants.IsFlakyProperty),
                Layer = ProjectPage.GetTestCaseDropDownProperty(TestCaseConstants.LayerProperty),
                Automation = ProjectPage.GetTestCaseDropDownProperty(AutomationStatus)
            };
            ProjectPage.QuiteWindowMode();
            return actualTestCase;
        }
    }
}
