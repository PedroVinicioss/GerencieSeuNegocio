using FluentMigrator.Runner;
using GerencieSeuNegocio.Domain.Repositories;
using GerencieSeuNegocio.Domain.Repositories.Business;
using GerencieSeuNegocio.Domain.Repositories.Customer;
using GerencieSeuNegocio.Domain.Repositories.User;
using GerencieSeuNegocio.Domain.Security.Tokens;
using GerencieSeuNegocio.Domain.Services.LoggedUser;
using GerencieSeuNegocio.Infraestructure.DataAccess;
using GerencieSeuNegocio.Infraestructure.DataAccess.Repositories;
using GerencieSeuNegocio.Infraestructure.Extensions;
using GerencieSeuNegocio.Infraestructure.Security.Tokens.Access.Generator;
using GerencieSeuNegocio.Infraestructure.Security.Tokens.Access.Validator;
using GerencieSeuNegocio.Infraestructure.Services.LoggedUser;
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
            AddTokens(services, config);
            AddLoggedUser(services);
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
            services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();

            services.AddScoped<IBusinessReadOnlyRepository, BusinessRepository>();
            services.AddScoped<IBusinessWriteOnlyRepository, BusinessRepository>();

            services.AddScoped<ICustomerReadOnlyRepository, CustomerRepository>();
            services.AddScoped<ICustomerWriteOnlyRepository, CustomerRepository>();
        }

        private static void AddTokens(IServiceCollection services, IConfiguration config)
        {
            var expirationTimeMinutes = config.GetValue<int>("Settings:Jwt:ExpirationTimeMinutes");
            var signingKey = config.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<IAccessTokenGenerator>(option => new JwtTokenGenerator((uint)expirationTimeMinutes, signingKey!));
            services.AddScoped<IAccessTokenValidator>(option => new JwtTokenValidator(signingKey!));
        }

        private static void AddLoggedUser(IServiceCollection services) => services.AddScoped<ILoggedUser, LoggedUser>();
    }
}
