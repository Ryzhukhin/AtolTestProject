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

        public ProjectDbSettings DbSettings { get; }

        public static ProjectConfiguration ReadFromFile(string path)
        {
            ProjectDbSettings dbSettings = null;

            return new ProjectConfiguration(
                dbSettings: dbSettings);
        }

        public static ProjectConfiguration OverrideWithEnvironment()
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            var dbSettings = new ProjectDbSettings(dbType: DbType.MsSql, 
                                                    connectionString: connectionString);

            return new ProjectConfiguration(
                dbSettings: dbSettings);
        }
    }
}
