using Microsoft.EntityFrameworkCore;
using Project.Bll.Core.Interfaces;

namespace Project.Dal.Ef
{
    public class EfUnitOfWorkFactory : IUnitOfWorkFactory
    {
        enum ConnectionType
        {
            MsSql
        }

        private readonly string _connectionString;
        private readonly ConnectionType _connectionType;

        public static EfUnitOfWorkFactory CreateMsSqlBy(string connectionString)
        {
            return new EfUnitOfWorkFactory(connectionString, ConnectionType.MsSql);
        }

        private EfUnitOfWorkFactory(string connectionString, ConnectionType connectionType)
        {
            _connectionString = connectionString;
            this._connectionType = connectionType;
        }

        public ProjectDbContext GetContext()
        {
            var builder = new DbContextOptionsBuilder<ProjectDbContext>();

            builder.UseSqlServer(_connectionString);

            return new ProjectDbContext(builder.Options);
        }

        public IUnitOfWork Create()
        {
            EfUnitOfWork efUnitOfWork = new EfUnitOfWork(GetContext());
            efUnitOfWork.InitializeContext();
            return efUnitOfWork;
        }

        public override string ToString()
        {
            return _connectionType.ToString();
        }
    }
}