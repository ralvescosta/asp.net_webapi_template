using AspNet.Manage.StatusCode.Domain;
using OneOf;

namespace AspNet.Manage.StatusCode.Application
{
    public interface IUserService
    {
        OneOf<User, AlreadyExisteException, InternalErrorException> Create(CreateUserViewModel viewModel);
    }
}