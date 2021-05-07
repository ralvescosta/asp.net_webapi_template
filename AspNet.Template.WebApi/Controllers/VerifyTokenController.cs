using AspNet.Template.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AspNet.Template.Application.Interfaces;

namespace AspNet.Template.WebApi.Controllers
{
  [ApiController]
    [Route("[controller]")]
    public class VerifyTokenController : ControllerBase
    {
        private readonly ISignInUserService _signInUserService;
        public VerifyTokenController(ISignInUserService signInUserService)
        {
            _signInUserService = signInUserService;
        }
        [HttpPost]
        public IActionResult Post([FromHeader] string authorization)
        {
            var audience = Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var accessToken = _signInUserService.VerifyToken(authorization, audience);
            
            return accessToken.Match<IActionResult>(
                success => Ok(success), 
                failure => Problem()
            );
        }
    }
    
}