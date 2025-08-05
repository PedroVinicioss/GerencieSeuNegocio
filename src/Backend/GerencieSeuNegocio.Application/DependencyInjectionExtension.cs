using GerencieSeuNegocio.Application.Services.AutoMapper;
using GerencieSeuNegocio.Application.Services.Cryptography;
using GerencieSeuNegocio.Application.UseCases.Login.DoLogin;
using GerencieSeuNegocio.Application.UseCases.User.Create;
using GerencieSeuNegocio.Application.UseCases.User.Update;
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
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            //services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        }

        private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration config)
        {
            var additionalKey = config.GetValue<string>("Settings:Password:AdditionalKey");

            services.AddScoped(option => new PasswordEncripter(additionalKey!));
        }
    }
}
