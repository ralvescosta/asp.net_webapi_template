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
        public IActionResult Post([FromHeader] string authorization, [FromHeader] string surname)
        {
            var accessToken = _signInUserService.VerifyToken(authorization, surname);
            
            return accessToken.Match<IActionResult>(
                success => Ok(success), 
                failure => Problem()
            );
        }
    }
    
}