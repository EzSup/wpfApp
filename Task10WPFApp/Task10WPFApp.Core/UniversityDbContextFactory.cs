using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10WPFApp.Core
{
    public class UniversityDbContextFactory : IDesignTimeDbContextFactory<UniversityDbContext>
    {
        public UniversityDbContext CreateDbContext(string[] args)
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "appsettings.json");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configPath, optional: true, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<UniversityDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure();
                });

            return new UniversityDbContext(optionsBuilder.Options);
        }
    }
}
