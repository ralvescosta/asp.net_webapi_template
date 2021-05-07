using AspNet.Template.Application.Interfaces;
using AspNet.Template.Application.Manager;
using AspNet.Template.Application.Services;
using AspNet.Template.Data.Context;
using AspNet.Template.Data.Repositories;
using AspNet.Template.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet.Template.WebApi.Extensions
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IJwkCredentialsService, JwkCredentialsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<ISignInUserService, SignInUserService>();
            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDbContext, DbContext>();
            return services;
        }
    }
}