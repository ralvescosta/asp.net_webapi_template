using System;
using AspNet.Template.Application.Interfaces;
using AspNet.Template.Domain.Entities;
using AspNet.Template.Domain.ViewModels;
using AspNet.Template.Shared.Utils;

namespace AspNet.Template.Application.Services
{
  public class SignInUserService: ISignInUserService
    {
        private readonly ITokenManager _tokenManager;
        public SignInUserService(ITokenManager tokenManager) 
        {
            _tokenManager = tokenManager;
        }
        public Result<AuthenticatedUserViewModel> SignIn(UserSignInViewModel viewModel, string audience)
        {
            var user = new User 
            {
                Id = 10,
                Email = viewModel.Email,
                Age = 28,
                Name = "Jhone Due"
            };
            var expireDate = DateTime.UtcNow.AddHours(2);

            var accessToken = _tokenManager.GenerateToken(user, audience, expireDate);
            return accessToken.Match<Result<AuthenticatedUserViewModel>>(
                success => new Result<AuthenticatedUserViewModel>(
                    new AuthenticatedUserViewModel 
                    {
                        Email = viewModel.Email,
                        AccessToken = success,
                        ExpiredAt = expireDate.ToString()
                    }), 
                failure => new Result<AuthenticatedUserViewModel>(failure)
            );
        }
        
    }
}