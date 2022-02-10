using Qase_Test.Core;
using Qase_Test.Fakers;

namespace Qase_Test.Models
{
    public static class ModelsSettings
    {
        private static readonly string ProjectName = ProjectFaker.GetFakeProject().ProjectName;
        private static readonly string ProjectCode = ProjectFaker.GetFakeProject().ProjectCode;
        private static readonly string WrongProjectCode = ProjectFaker.GetFakeProject().WrongProjectCode;
        private static readonly string ProjectDescription = ProjectFaker.GetFakeProject().ProjectDescription;

        public static User GetUser() =>
            new()
            {
                Email = ReadProperties.Email,
                Password = ReadProperties.Password
            };

        public static Project GetProject() =>
            new()
            {
                ProjectName = ProjectName,
                ProjectCode = ProjectCode,
                ProjectDescription = ProjectDescription
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
