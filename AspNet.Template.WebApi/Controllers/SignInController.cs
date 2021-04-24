using System.Security.Claims;
using AspNet.Template.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AspNet.Template.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignInController : ControllerBase
    {

        [HttpGet]
        public IActionResult Post(UserSignInViewModel userSignInViewModel)
        {
            var accessToken = JwtGenerator(userSignInViewModel.Email);
            var authenticatedUser = new AuthenticatedUserViewModel
            {
                AccessToken = accessToken,
                Email = userSignInViewModel.Email,
                ExpiredAt = DateTime.Now.AddHours(1).ToString()
            };
            return Ok(authenticatedUser);
        }

        private string JwtGenerator(string email, int userId = 1)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)
            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("private key");
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "Identity Service",
                Audience = "https://origin",
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }
         private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
    
}