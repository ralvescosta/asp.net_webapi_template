using AspNet.Manage.StatusCode.Application;
using AspNet.Manage.StatusCode.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet.Manage.StatusCode.WebApi.Extensions
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