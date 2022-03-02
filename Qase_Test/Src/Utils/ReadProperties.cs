using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Qase_Test.Constants;

namespace Qase_Test.Utils
{
    public class ReadProperties
    {
        private static readonly Lazy<IConfiguration> Configurations;
        private static readonly string Filepath =
            $@"src{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{ResourcesConstants.AppSettings}.{ResourcesConstants.Json}";

        public static IConfiguration Configuration => Configurations.Value;

        static ReadProperties() =>
            Configurations = new Lazy<IConfiguration>(BuildConfiguration);

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(Filepath);

            var appSettingFiles = Directory.EnumerateFiles(basePath,
                $"{ResourcesConstants.AppSettings}.*.{ResourcesConstants.Json}");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}
