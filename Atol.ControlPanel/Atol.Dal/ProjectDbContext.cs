using Microsoft.EntityFrameworkCore;
using Project.Bll.Core.StoredItems;

namespace Project.Dal.Ef
{
    public class ProjectDbContext:DbContext
    {
        private readonly string _connectionString;

        public ProjectDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProjectDbContext(DbContextOptions options) : base(options)
        {
            _connectionString = null;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (_connectionString != null)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserStoredItem> Users { get; set; }
        public DbSet<ProductsStoredItem> Products { get; set; }
        public DbSet<TransactionsStoredItem> Transactions { get; set; }
    }
}
