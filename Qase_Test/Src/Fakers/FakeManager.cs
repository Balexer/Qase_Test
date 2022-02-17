using Qase_Test.Core;
using Qase_Test.Models;

namespace Qase_Test.Fakers
{
    public static class FakeManager
    {
        private static readonly Project Project = ProjectFaker.GetFakeProject();
        private static readonly string ProjectName = Project.ProjectName;
        private static readonly string WrongProjectCode = Project.WrongProjectCode;
        private static readonly string ProjectDescription = Project.ProjectDescription;

        public static User GetUser() =>
            new()
            {
                Email = ReadProperties.Email,
                Password = ReadProperties.Password
            };

        public static Project GetInvalidProject() =>
            new()
            {
                ProjectName = ProjectName,
                ProjectCode = WrongProjectCode,
                ProjectDescription = ProjectDescription
            };
    }
}
