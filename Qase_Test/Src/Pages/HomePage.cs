using OpenQA.Selenium;
using Qase_Test.Pages.Base;
using Qase_Test.Wrappers;

namespace Qase_Test.Pages
{
    public class HomePage : BasePage
    {
        private const string ProjectSelector = "//a[text()='replace']";
        private static readonly By DropDownDeleteSelector =
            By.XPath("//a[@aria-expanded='true']/following-sibling::div/div/a[@class='text-danger']");
        private static readonly By CreateNewProjectButtonSelector = By.Id("createButton");
        private static readonly string ProjectDropdownMenuSelector =
            $"{ProjectSelector}/../../following-sibling::td[@class='text-end']/div/a";

        public HomePage() : base(By.XPath($"//h1[text()='Projects']"))
        {
        }

        public static void ClickDropdownMenuDelete() =>
            new Button(DropDownDeleteSelector).Click();

        public static bool FindProjectByName(string projectName) =>
            new Text(ReplaceLocator(ProjectSelector, projectName)).IsDisplayed();


        public static void CreateNewProject() =>
            new Button(CreateNewProjectButtonSelector).Click();

        public static void OpenProjectDropdownMenu(string projectName) =>
            new Button(ReplaceLocator(ProjectDropdownMenuSelector, projectName)).Click();

        public static void OpenProjectByName(string projectName) =>
            new Button(ReplaceLocator(ProjectSelector, projectName)).Click();
    }
}
