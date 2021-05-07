using System.ComponentModel.DataAnnotations;
using AspNet.Template.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Template.WebApi.Controllers
{
  [ApiController]
    [Route("[controller]")]
    public class IdentityCredentialsController : ControllerBase
    {
        private readonly IJwkCredentialsService _jwtCredentailsService;
        public IdentityCredentialsController(IJwkCredentialsService jwtCredentailsService)
        {
            _jwtCredentailsService = jwtCredentailsService;
        }

        [HttpGet]
        public IActionResult Get([FromHeader] [Required] string authorization)
        {
            var result = _jwtCredentailsService.GetJWK();
            
            return result.Match<IActionResult>(
                success => Ok(success),
                failure => Problem()
            );
        }
    }
}