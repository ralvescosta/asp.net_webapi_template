using System;
using AspNet.Manage.StatusCode.Application;
using AspNet.Manage.StatusCode.Domain;
using OneOf;

namespace AspNet.Manage.StatusCode.Data
{
    public class UserRepository : IUserRepository
    {
        public OneOf<User, InternalErrorException> Create(User user)
        {
            return new InternalErrorException("Ops!");
        }
    }
}
