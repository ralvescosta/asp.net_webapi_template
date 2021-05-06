using AspNet.Template.Domain.Entities;
using AspNet.Template.Domain.ViewModels;
using AspNet.Template.Shared.Utils;

namespace AspNet.Template.Application.Interfaces
{
    public interface ISignInUserService
    {
        Result<AuthenticatedUserViewModel> SignIn(UserSignInViewModel viewModel);
        Result<User> VerifyToken(string accessToken, string audience);
    }
}