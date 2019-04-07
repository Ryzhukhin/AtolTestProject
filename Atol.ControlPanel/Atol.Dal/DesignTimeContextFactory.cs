using Microsoft.EntityFrameworkCore.Design;

namespace Project.Dal.Ef
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            return new ProjectDbContext(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AtolTestProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}