using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages
{
    public class HomePage : BasePage
    {
        private const string ProjectSelector = "//a[text()='replace']";
        private readonly By _dropDownDeleteSelector =
            By.XPath("//a[@aria-expanded='true']/following-sibling::div/div/a[@class='text-danger']");
        private readonly By _createNewProjectButtonSelector = By.Id("createButton");
        private readonly string _projectDropdownMenuSelector =
            $"{ProjectSelector}/../../following-sibling::td[@class='text-end']/div/a";

        public HomePage() : base(By.XPath($"//h1[text()='Projects']"))
        {
        }

        public void ClickDropdownMenuDelete() =>
            BaseElement.GetElement(_dropDownDeleteSelector).Click();

        public static bool FindProjectByName(string projectName)
        {
            try
            {
                return BaseElement.GetElement(ReplaceLocator(ProjectSelector, projectName)).Displayed;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public void CreateNewProject() =>
            BaseElement.GetElement(_createNewProjectButtonSelector).Click();

        public void OpenProjectDropdownMenu(string projectName) =>
            BaseElement.GetElement(ReplaceLocator(_projectDropdownMenuSelector, projectName)).Click();

        public static void OpenProjectByName(string projectName) =>
            BaseElement.GetElement(ReplaceLocator(ProjectSelector, projectName)).Click();
    }
}
