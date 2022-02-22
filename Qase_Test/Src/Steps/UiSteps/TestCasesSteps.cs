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
        private readonly ProjectPage _projectPage;
        private readonly CreateTestCasePage _createTestCasePage;
        private const string Preconditions = "Preconditions";
        private const string Postconditions = "Postconditions";
        private const string AutomationStatus = "Automation";

        public TestCasesSteps()
        {
            _projectPage = new ProjectPage();
            _createTestCasePage = new CreateTestCasePage();
        }

        [AllureStep("Create test case in project")]
        public void CreateTestCaseInProject(Project project, TestCase testCase)
        {
            HomePage.OpenProjectByName(project.ProjectName);
            _projectPage.CreateTestCase();
            _createTestCasePage.SetTitle(testCase.CaseTitle);
            _createTestCasePage.SetTextProperty(testCase.Description, TestCaseConstants.DescriptionProperty);
            _createTestCasePage.SetTextProperty(testCase.Preconditions, TestCaseConstants.PreconditionsProperty);
            _createTestCasePage.SetTextProperty(testCase.Postconditions, TestCaseConstants.PostconditionsProperty);
            _createTestCasePage.SetDropDownProperty(testCase.Severity, TestCaseConstants.SeverityProperty);
            _createTestCasePage.SetDropDownProperty(testCase.Status, TestCaseConstants.StatusProperty);
            _createTestCasePage.SetDropDownProperty(testCase.Priority, TestCaseConstants.PriorityProperty);
            _createTestCasePage.SetDropDownProperty(testCase.Behavior, TestCaseConstants.BehaviorProperty);
            _createTestCasePage.SetDropDownProperty(testCase.Type, TestCaseConstants.TypeProperty);
            _createTestCasePage.SetDropDownProperty(testCase.IsFlaky, TestCaseConstants.IsFlakyProperty);
            _createTestCasePage.SetDropDownProperty(testCase.Layer, TestCaseConstants.LayerProperty);
            _createTestCasePage.SetDropDownProperty(testCase.Automation, TestCaseConstants.AutomationProperty);
            _createTestCasePage.SaveTestCase();
        }

        [AllureStep("Create test case with required fields")]
        public void CreateDefaultTestCase(Project project, TestCase testCase)
        {
            HomePage.OpenProjectByName(project.ProjectName);
            _projectPage.CreateTestCase();
            _createTestCasePage.SetTitle(testCase.CaseTitle);
            _createTestCasePage.SaveTestCase();
        }

        [AllureStep("Get information from test case")]
        public TestCase GetTestCase(TestCase testCase)
        {
            ProjectPage.SelectTestCase(testCase.CaseTitle);
            _projectPage.ChooseWindowMode();
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
            _projectPage.QuiteWindowMode();
            return actualTestCase;
        }
    }
}
