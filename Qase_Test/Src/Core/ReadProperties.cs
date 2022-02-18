using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Qase_Test.Core
{
    public static class ReadProperties
    {
        private const string AppSettings = "appSettings";
        private const string Json = "json";
        private static readonly Lazy<IConfiguration> Configurations;
        private static readonly string Filepath =
            $@"src{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{AppSettings}.{Json}";

        private static IConfiguration Configuration => Configurations.Value;

        public static string Url => Configuration[nameof(Url)];

        public static string Browser => Configuration[nameof(Browser)];

        public static TimeSpan Timeout => TimeSpan.FromSeconds(Convert.ToDouble(Configuration[nameof(Timeout)]));

        public static string Email => Configuration[nameof(Email)];

        public static string Password => Configuration[nameof(Password)];

        static ReadProperties()
        {
            Configurations = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(Filepath);

            var appSettingFiles = Directory.EnumerateFiles(basePath, $"{AppSettings}.*.{Json}");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}
