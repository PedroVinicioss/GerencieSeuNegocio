using Microsoft.Extensions.Configuration;

namespace GerencieSeuNegocio.Infraestructure.Extensions
{
    public static class ConfigurationExtension
    {
        public static string ConnectionString(this IConfiguration config)
        {
            return config.GetConnectionString("Connection")!;
        }
    }
}
