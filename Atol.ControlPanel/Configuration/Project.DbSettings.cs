using System;
using Microsoft.Extensions.Configuration;
using Project.Bll.Core.Interfaces;
using Project.Dal.Ef;

namespace Project.Configuration
{
    public class ProjectDbSettings
    {
        public static ProjectDbSettings InMemory
            => new ProjectDbSettings(DbType.MsSql, "");

        public DbType DbType { get; } = DbType.MsSql;

        public ProjectDbSettings OverrideWithEnvironment()
        {
            DbType dbType = this.DbType;
            var dbTypeString = Environment.GetEnvironmentVariable("DbType");

            if (String.Equals(dbTypeString, DbType.MsSql.ToString()))
                dbType = DbType.MsSql;
            else
                throw new NotImplementedException();

            var connectionString = Environment.GetEnvironmentVariable("connectionString");

            return new ProjectDbSettings(
                dbType: dbType,
                connectionString: connectionString ?? this.ConnectionString);
        }

        public static ProjectDbSettings ReadFrom(IConfigurationRoot configuration)
        {
            var dbType = configuration.GetSection("dbType").Get<DbType>();
            var connectionString = configuration.GetConnectionString("DatabaseConnectionString");
            return new ProjectDbSettings(dbType, connectionString);
        }

        public ProjectDbSettings(DbType dbType, string connectionString)
        {
            DbType = dbType;
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public IUnitOfWorkFactory CreateUnitOfWorkFactory()
        {
            switch (DbType)
            {
                case DbType.MsSql:
                    return EfUnitOfWorkFactory.CreateMsSqlBy(ConnectionString);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }


}
