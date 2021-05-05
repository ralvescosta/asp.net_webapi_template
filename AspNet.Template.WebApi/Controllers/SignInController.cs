using AspNet.Template.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using AspNet.Template.Application.Services;

namespace AspNet.Template.WebApi.Controllers
{
  [ApiController]
    [Route("[controller]")]
    public class SignInController : ControllerBase
    {
        private readonly GenerateToken _tokenManager;
        public SignInController(GenerateToken tokenManager)
        {
            _tokenManager = tokenManager;
        }
        [HttpPost]
        public IActionResult Post(UserSignInViewModel userSignInViewModel)
        {
            var accessToken = _tokenManager.JwtGenerator(userSignInViewModel.Email, userSignInViewModel.Audiency);
            var authenticatedUser = new AuthenticatedUserViewModel
            {
                AccessToken = accessToken,
                Email = userSignInViewModel.Email,
                ExpiredAt = DateTime.Now.AddHours(1).ToString()
            };
            return Ok(authenticatedUser);
        }
    }
    
}