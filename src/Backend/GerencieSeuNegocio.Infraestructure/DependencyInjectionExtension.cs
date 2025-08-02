using FluentMigrator.Runner;
using GerencieSeuNegocio.Domain.Repositories;
using GerencieSeuNegocio.Domain.Repositories.User;
using GerencieSeuNegocio.Infraestructure.DataAccess;
using GerencieSeuNegocio.Infraestructure.DataAccess.Repositories;
using GerencieSeuNegocio.Infraestructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GerencieSeuNegocio.Infraestructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            AddDbContext(services, config);
            AddFluentMigrator(services, config);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.ConnectionString();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));

            services.AddDbContext<GerencieSeuNegocioDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseMySql(connectionString, serverVersion);
            });
        }
        private static void AddFluentMigrator(IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.ConnectionString();

            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                    .AddMySql5()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(Assembly.Load("GerencieSeuNegocio.Infraestructure"))
                    .For.All();
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }
    }
}
