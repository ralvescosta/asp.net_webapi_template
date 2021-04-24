using System;
using AspNet.Template.Application.Interfaces;
using AspNet.Template.Domain.Entities;
using AspNet.Template.Shared.Utils;
using Microsoft.Extensions.Logging;

namespace AspNet.Template.Data.Repositories
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
