using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AspNet.Template.Shared.Configurations;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace AspNet.Template.Application.Services
{
    public class GenerateToken
    {
        public string JwtGenerator(string email, string audience, int userId = 1)
        {
            var privateKey = "MIIEogIBAAKCAQEAsxKOqq6KxTM38/kgsHgw2YRbGSj7sgLJANB2MPgtRW0lcjyi6Wz4UYEy4nOGKnMW+K0de98y51MMfyxb6gb7r74CdqNftqenKZZtqtUvD8w+W4mhw0cGE7YwuNx6h/nckZCJa/TLW7bPL1pi8kW852L/NSqAWWibVwC5OeLyJtr9V3CbIv2FgiSNgMnbdtdvfhcoPeL0146ph0jvTMl/i9cFATf6suwSBx4M7316MoFjtr8fLkJAUJhOrrCp5y+BohIrjL15U14WkL6X/Jz6FbtNYU7S2YVfhVh9dSrP/5Usbzf86N/7t431pAZd+F7W3itAT/Ti5oOntKTghwbRwwIDAQABAoIBAED0TkOjJDr7pSQeDbl1H2MHG3Q45XNgh0CAXR7OJr20JY0WaZF6MWh/ENILTXNAY+i4AqXYBELcYQAQOxbciZbpuUMHZ8R9c6kmI4l/4p48W7IgbkjDDnU/9NRZRSjlfRhf8TjzhoAyA10N0C5JFYho5GGIlR3ZT99zJ7zTkTp+QE2U6sSayconuUk5QUIkSaWa59csmJgmhgfFzLdd1MSr8RcFTQlDuS7+Oqi3pzg9HhoOHo1b3IGdLghlP7vqgFHoPJT5idsx+4CEi5sVaveEmSxzLw9gAOIFKYGZ8dc5N/Ft/qGgBNx8tixB801HzKmObZ+SziCuqZz8spZARiECgYEA8Va+F5OkmwgY+yxqLgvXpVb+9TU8UIAplxxo+xCCwUaLMGnLmDUAe6h0x3f4DWsyr/bePZUnwr+cQiiL0YP2DyjHsQ0n0CESeH7eTGIZf43T65BiNTZPWaA2RCtSQh8JpLrG8TFDgXDrs2JOF5UbRRbahOiwUY5j+FC/sqqRHdUCgYEAvfN1uuVlbNt3cIxCRd66OXC/k6FvuQKAcdlSvvspRyOPZcS2pZ6bT4YU/IH2txXq07iClOKxtbiusD0NSAcapTZ5Z4gtTPaNBUu5/+FRvzoSBQ/7yKSOdH387NeSTa51OcuNbp+h6+eXawoFeMByXzxnyVaizKpN1na80lYTRTcCgYBLKNKGkSqARaNSBeEDehism01HnE6uW1uYffaLyfaOrqOGbkxDmK4P1MSZolkUBMCCYIWR9DOvyPCnAe2ZUFl/Gxoln404mjQgZpJgg2Shfs/y2sJbBBDuPqDn1f4GLZhZPvnZ/5egZkRhV0ouufcGKznejoDqxUeI+8zXnZsYCQKBgBbCzo+nn0CtB6Hf3K0cpDnvzbT1+jo0F4oM3YJu/CI/G5a5PJ2Z5Mhhq7AaLqL/qFTYXiVTCLJav+v0VNwVpda4MVH7mloHjRxeV5pWuIHuhmw+3w/K0BsbYaxLpIdUaU2Um4zu6esnpBg6ai9u+AV7aoBQtk9J9OvG7JdToxl/AoGAYSWFOu7Wtb4TVql/frnL3WTBFh+YxDRYp53RK/iCQmemNFBcGQHdQwRQcJfiHzijvmHn3jSAHdRcVZas/rCliW21CkXAz8OFL6wenKLQailatvsP5Tf+fVXBkQsqfgb1D5IpPdhvjSnKEapPjtbLZfF4M0Tu17v1xq22c4EsojI=";
            var privateKeyRaw = Convert.FromBase64String(privateKey);

            var provider = new RSACryptoServiceProvider();
            provider.ImportRSAPrivateKey(new ReadOnlySpan<byte>(privateKeyRaw), out _);
            var rsaSecurityKey = new RsaSecurityKey(provider) 
            {
                KeyId = Guid.NewGuid().ToString()
            };

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

            var token = tokenHandler.CreateToken(
                new SecurityTokenDescriptor
                {
                    Issuer = "Identity Service",
                    Audience = audience,
                    Subject = identityClaims,
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSsaPssSha256)
                });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}