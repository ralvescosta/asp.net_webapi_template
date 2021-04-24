using AspNet.Template.Domain.Entities;
using AspNet.Template.Domain.ViewModels;
using AspNet.Template.Shared.Utils;

namespace AspNet.Template.Domain.Services
{
  public interface IUserService
    {
        Result<User> Create(CreateUserViewModel viewModel);
    }
}