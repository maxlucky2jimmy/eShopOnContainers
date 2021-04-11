using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.eShopOnContainers.BuildingBlocks.IntegrationEventLogEF;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Catalog.API.Infrastructure.IntegrationEventMigrations
{
    public class IntegrationEventLogContextDesignTimeFactory : IDesignTimeDbContextFactory<IntegrationEventLogContext>
    {
        public IntegrationEventLogContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                           .AddJsonFile("appsettings.json")
                           .AddEnvironmentVariables()
                           .Build();

            var optionsBuilder = new DbContextOptionsBuilder<IntegrationEventLogContext>();

            optionsBuilder.UseSqlServer(config["ConnectionString"], sqlServerOptionsAction: o => o.MigrationsAssembly("Catalog.API"));

            return new IntegrationEventLogContext(optionsBuilder.Options);
        }
    }
}