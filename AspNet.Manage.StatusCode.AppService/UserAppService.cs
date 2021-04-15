using AspNet.Manage.StatusCode.Domain;
using AspNet.Manage.StatusCode.Application;
using OneOf;

namespace AspNet.Manage.StatusCode.AppService
{
  public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }
        public OneOf<User, AlreadyExisteException, InternalErrorException> RegisterUser(CreateUserViewModel viewModel)
        {
            return _userService.Create(viewModel);
        }
    }
}
