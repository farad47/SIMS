using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIMS.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabase(configuration);

            return services;
        }

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' is missing.");
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                var providerValue = configuration["Database:Provider"];
                if (!Enum.TryParse<DatabaseProvider>(providerValue, out var provider))
                {
                    throw new InvalidOperationException(
                        $"Invalid database provider '{providerValue}'.");
                }

                switch (provider)
                {
                    case DatabaseProvider.Postgres:
                        options.UseNpgsql(connectionString);
                        break;

                    default:
                        throw new NotSupportedException(
                            $"Database provider '{provider}' is not supported.");
                }
            });

            return services;
        }
    }
}
