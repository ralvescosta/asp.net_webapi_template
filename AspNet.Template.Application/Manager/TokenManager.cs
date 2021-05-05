using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AspNet.Template.Application.Interfaces;
using AspNet.Template.Domain.Entities;
using AspNet.Template.Shared.Configurations;
using AspNet.Template.Shared.Utils;
using Microsoft.IdentityModel.Tokens;

namespace AspNet.Template.Application.Manager
{
  public class TokenManager : ITokenManager
  {
        private readonly Configurations _configs;
        public TokenManager(Configurations configs) 
        {
            _configs = configs;
        }
      
        public Result<string> GenerateToken(User user, string audience, DateTime expireDate)
        {
            try 
            {
                var privateKeyRaw = Convert.FromBase64String(_configs.Keys.PrivateKey);

                using var rsa = RSA.Create();
                rsa.ImportRSAPrivateKey(privateKeyRaw, out _);
                var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
                {
                    CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false}
                };

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
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
                        Expires = expireDate,
                        SigningCredentials = signingCredentials
                    });

                var encodedToken = tokenHandler.WriteToken(token);

                return new Result<string>(encodedToken);
            }
            catch(Exception ex) 
            {
                return new Result<string>(ex);
            }
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
  }
}