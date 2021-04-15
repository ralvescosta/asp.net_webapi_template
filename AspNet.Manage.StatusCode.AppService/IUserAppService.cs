using AspNet.Manage.StatusCode.Domain;
using OneOf;

namespace AspNet.Manage.StatusCode.AppService
{
    public interface IUserAppService
    {
        OneOf<User, AlreadyExisteException, InternalErrorException> RegisterUser(CreateUserViewModel viewModel);
    }
}