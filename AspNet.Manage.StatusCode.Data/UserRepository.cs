using System;
using AspNet.Manage.StatusCode.Application;
using AspNet.Manage.StatusCode.Domain;
using Microsoft.Extensions.Logging;
using OneOf;

namespace AspNet.Manage.StatusCode.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }
        public OneOf<User, InternalErrorException> Create(User user)
        {
            var ex = new InternalErrorException("Ops!");
            _logger.LogError(ex, "Try to create an user");
            return ex;
        }
    }
}
