using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Qase_Test.Core
{
    public static class ReadProperties
    {
        private static readonly Lazy<IConfiguration> SConfiguration;
        private static IConfiguration Configuration => SConfiguration.Value;

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(
                    $@"src{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}appSettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }

        static ReadProperties()
        {
            SConfiguration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        public static string Url => Configuration[nameof(Url)];
        public static string Browser => Configuration[nameof(Browser)];
        public static TimeSpan Timeout => TimeSpan.FromSeconds(Convert.ToDouble(Configuration[nameof(Timeout)]));
        public static string Email => Configuration[nameof(Email)];
        public static string Password => Configuration[nameof(Password)];
        public static string WrongPassword => Configuration[nameof(WrongPassword)];
        public static string ProjectName => Configuration[nameof(ProjectName)];
        public static string ProjectCode => Configuration[nameof(ProjectCode)];
        public static string WrongProjectName => Configuration[nameof(WrongProjectName)];
        public static string ProjectDescription => Configuration[nameof(ProjectDescription)];
        public static string TestCaseName => Configuration[nameof(TestCaseName)];
        public static string EmptyTestCaseName => Configuration[nameof(EmptyTestCaseName)];
        public static string ExistingProjectCode => Configuration[nameof(ExistingProjectCode)];
        public static string Token => Configuration[nameof(Token)];
        public static string MemberToken => Configuration[nameof(MemberToken)];
        public static string AnotherProjectCode => Configuration[nameof(AnotherProjectCode)];
        public static string HomeUrl => Configuration[nameof(HomeUrl)];
    }
}
