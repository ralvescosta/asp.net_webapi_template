using AspNet.Template.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AspNet.Template.Application.Interfaces;

namespace AspNet.Template.WebApi.Controllers
{
  [ApiController]
    [Route("[controller]")]
    public class SignInController : ControllerBase
    {
        private readonly ISignInUserService _signInUserService;
        public SignInController(ISignInUserService signInUserService)
        {
            _signInUserService = signInUserService;
        }
        [HttpPost]
        public IActionResult Post(UserSignInViewModel userSignInViewModel)
        {
            var audience = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var accessToken = _signInUserService.SignIn(userSignInViewModel, audience);

            return accessToken.Match<IActionResult>(
                success => Ok(success), 
                failure => Problem()
            );
        }
    }
    
}