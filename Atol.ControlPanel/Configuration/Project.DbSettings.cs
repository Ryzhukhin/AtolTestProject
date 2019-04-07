using System;
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

            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            return new ProjectDbSettings(
                dbType: dbType,
                connectionString: connectionString ?? this.ConnectionString);
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
