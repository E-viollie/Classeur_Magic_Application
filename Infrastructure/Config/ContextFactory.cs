

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Config
{
    /// <summary>
    /// Factory pour la construction du bd context.
    /// </summary>
    public sealed class ContextFactory : IDesignTimeDbContextFactory<CardContext>
    {
        /// <summary>
        /// Création de context
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CardContext CreateDbContext(string[] args)
        {
            string connectionString = this.ReadDefaultConnectionStringFromAppSettings();

            DbContextOptionsBuilder<CardContext> builder = new DbContextOptionsBuilder<CardContext>();
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure"));
            return new CardContext(builder.Options);
        }

        /// <summary>
        /// Lecteur par défault de la connection string 
        /// provenant appSetting
        /// </summary>
        /// <returns></returns>
        private string ReadDefaultConnectionStringFromAppSettings()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DevelopmentConnection");
            return connectionString;
        }
    }
}
