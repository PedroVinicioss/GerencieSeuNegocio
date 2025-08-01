using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerencieSeuNegocio.Infraestructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            AddDbContext(services, config);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration config)
        {
            //var connectionString = config.GetConnectionString("Connection");
            //var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));

            //services.AddDbContext<MyRecipeBookDbContext>(dbContextOptions =>
            //{
            //    dbContextOptions.UseMySql(connectionString, serverVersion);
            //});
        }

        private static void AddRepositories(IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            //services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }
    }
}
