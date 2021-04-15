using AspNet.Manage.StatusCode.Domain;
using OneOf;

namespace AspNet.Manage.StatusCode.Application
{
    public interface IUserRepository
    {
        OneOf<User, InternalErrorException> Create(User user);
    }
}