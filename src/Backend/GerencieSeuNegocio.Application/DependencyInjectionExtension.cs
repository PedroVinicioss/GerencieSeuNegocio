using GerencieSeuNegocio.Application.Services.AutoMapper;
using GerencieSeuNegocio.Application.Services.Cryptography;
using GerencieSeuNegocio.Application.UseCases.User.Register;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerencieSeuNegocio.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration config)
        {
            AddAutoMapper(services);
            AddUseCases(services);
            AddPasswordEncrypter(services, config);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration config)
        {
            var additionalKey = config.GetValue<string>("Settings:Password:AdditionalKey");

            services.AddScoped(option => new PasswordEncripter(additionalKey!));
        }
    }
}
