using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VeggieVibes.Infrastructure.DataAccess
{
    public class VeggieVibesDbContextFactory : IDesignTimeDbContextFactory<VeggieVibesDbContext>
    {
        public VeggieVibesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VeggieVibesDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new VeggieVibesDbContext(optionsBuilder.Options);
        }
    }
}
