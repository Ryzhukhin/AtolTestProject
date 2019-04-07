using Microsoft.EntityFrameworkCore.Design;

namespace Project.Dal.Ef
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            return new ProjectDbContext(
                "Username = postgres; " +
                "Password = Egor10203040; " +
                "Host = localhost; " +
                "Port = 5432; " +
                "Database = tsupdb;");
        }
    }
}