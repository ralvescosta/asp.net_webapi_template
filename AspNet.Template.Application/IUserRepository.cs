using AspNet.Template.Domain;
using OneOf;

namespace AspNet.Template.Application
{
    public interface IUserRepository
    {
        OneOf<User, InternalErrorException> Create(User user);
    }
}