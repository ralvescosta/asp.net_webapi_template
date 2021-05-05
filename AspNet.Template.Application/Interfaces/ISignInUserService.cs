using AspNet.Template.Domain.ViewModels;
using AspNet.Template.Shared.Utils;

namespace AspNet.Template.Application.Interfaces
{
    public interface ISignInUserService
    {
        Result<AuthenticatedUserViewModel> SignIn(UserSignInViewModel viewModel, string audience);
    }
}