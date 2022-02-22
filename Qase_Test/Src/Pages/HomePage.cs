using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Utils;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages
{
    public class HomePage : BasePage
    {
        private readonly By _dropDownDeleteSelector =
            By.XPath("//a[@aria-expanded='true']/following-sibling::div/div/a[@class='text-danger']");
        private readonly By _createNewProjectButtonSelector = By.Id("createButton");
        private const string HomePageTitleText = "Projects";
        private const string ProjectSelector = "//a[text()='replace']";
        private readonly string _projectDropdownMenuSelector =
            $"{ProjectSelector}/../../following-sibling::td[@class='text-end']/div/a";

        public HomePage() : base(new Title(HomePageTitleText).GetLocator())
        {
        }

        public void ClickDropdownMenuDelete() =>
            WebElementActions.GetElement(_dropDownDeleteSelector).Click();

        public static bool FindProjectByName(string projectName)
        {
            try
            {
                return WebElementActions.GetElement(ReplaceLocator(ProjectSelector, projectName)).Displayed;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public void CreateNewProject() =>
            WebElementActions.GetElement(_createNewProjectButtonSelector).Click();

        public void OpenProjectDropdownMenu(string projectName) =>
            WebElementActions.GetElement(ReplaceLocator(_projectDropdownMenuSelector, projectName)).Click();

        public static void OpenProjectByName(string projectName) =>
            WebElementActions.GetElement(ReplaceLocator(ProjectSelector, projectName)).Click();
    }
}
