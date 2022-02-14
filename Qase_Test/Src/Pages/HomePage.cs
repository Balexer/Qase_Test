using NLog;
using OpenQA.Selenium;
using Qase_Test.Core.Browser.Service;
using Qase_Test.Pages.Base;

namespace Qase_Test.Pages
{
    public class HomePage : BasePage
    {
        private static readonly By HomePageSelector = By.XPath("//h1[text()='Projects']");
        private readonly By _createNewProjectButtonSelector = By.Id("createButton");
        private const string ProjectSelector = "//a[text()='replace']";
        private const string DropDownDeleteSelector =
            "//a[@aria-expanded='true']/following-sibling::div/div/a[@class='text-danger']";
        private readonly string _projectDropdownMenuSelector =
            $"{ProjectSelector}/../../following-sibling::td[@class='text-end']/div/a";

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public HomePage() : base(HomePageSelector)
        {
        }

        public static void ClickDropdownMenuDelete() =>
            GetElement(By.XPath(DropDownDeleteSelector)).Click();

        public static bool FindProjectByName(string projectName)
        {
            try
            {
                return GetElement(By.XPath(ReplaceLocator(ProjectSelector, projectName))).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                Logger.Error(ex);
                return false;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.Error(ex);
                return false;
            }
        }

        public void CreateNewProject() =>
            GetElement(_createNewProjectButtonSelector).Click();

        public void OpenProjectDropdownMenu(string projectName) =>
            GetElement(By.XPath(ReplaceLocator(_projectDropdownMenuSelector, projectName))).Click();
    }
}
