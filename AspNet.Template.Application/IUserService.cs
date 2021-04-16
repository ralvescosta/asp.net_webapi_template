using AspNet.Template.Domain;
using OneOf;

namespace AspNet.Template.Application
{
    public interface IUserService
    {
        OneOf<User, AlreadyExisteException, InternalErrorException> Create(CreateUserViewModel viewModel);
    }
}