using AspNet.Template.Domain;
using AspNet.Template.Shared.Utils;

namespace AspNet.Template.Application
{
  public interface IUserService
    {
        Result<User> Create(CreateUserViewModel viewModel);
    }
}