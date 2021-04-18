using System;
using AspNet.Template.Application;
using AspNet.Template.Domain;
using AspNet.Template.Shared.Utils;
using Microsoft.Extensions.Logging;
using OneOf;

namespace AspNet.Template.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }
        public Result<User> Create(User user)
        {
            // var ex = new InternalErrorException("Ops!");
            // _logger.LogError(ex, "Try to create an user");
            // return ex;
            return new Result<User>(user);
        }
    }
}
