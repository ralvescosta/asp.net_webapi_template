using AspNet.Template.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Template.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JwksController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get([FromHeader] string authorization)
        {
            var jwks = new JwksViewModel
            {
                Kty = "RSA",
                Use = "sig",
                Kid = "pQudWyBLWmoHMWtkkyrCg",
                N = "589f792cf9eacca70f6f9713f3824ff13d1a97b55de10f36a21d13671307573ad708de5727d3b00a2c7cc50a45cbafdc6190d39fa39cde06144c5f1697ec4e18",
                E = "AQAB",
            };

            return Ok(jwks);
        }
    }
}