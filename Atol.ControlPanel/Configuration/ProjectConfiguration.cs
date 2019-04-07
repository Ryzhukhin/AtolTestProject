using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Configuration
{
    public class ProjectConfiguration
    {
        public ProjectConfiguration(ProjectDbSettings dbSettings)
        {
            DbSettings = dbSettings;
        }

        public static ProjectConfiguration ReadWithEnvironment() =>
            ReadFromFile(null).OverrideWithEnvironment();

        public ProjectDbSettings DbSettings { get; }

        public static ProjectConfiguration ReadFromFile(string path)
        {
            ProjectDbSettings dbSettings = null;

            return new ProjectConfiguration(
                dbSettings: dbSettings);
        }

        public ProjectConfiguration OverrideWithEnvironment()
        {
            var url = Environment.GetEnvironmentVariable("url");
            var dbSettings = DbSettings.OverrideWithEnvironment();

            return new ProjectConfiguration(
                dbSettings: dbSettings);
        }
    }
}
