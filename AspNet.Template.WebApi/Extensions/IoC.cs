using AspNet.Template.Application;
using AspNet.Template.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet.Template.WebApi.Extensions
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}