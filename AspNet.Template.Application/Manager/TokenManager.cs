using System.Linq;
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
                var privateKeyRaw = Convert.FromBase64String(_configs.JwtConfigs.PrivateKey);

                using var rsa = RSA.Create();
                rsa.ImportRSAPrivateKey(privateKeyRaw, out _);
                var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
                {
                    CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false}
                };

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Name, user.Name),
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
                        Issuer = _configs.JwtConfigs.Issuer,
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

        public Result<User> VerifyToken(string token, string audience)
        {
            var publicKeyRaw = Convert.FromBase64String(_configs.JwtConfigs.PublicKey);

            using var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(publicKeyRaw, out _);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configs.JwtConfigs.Issuer,
                ValidAudience = audience,
                IssuerSigningKey = new RsaSecurityKey(rsa),

                CryptoProviderFactory = new CryptoProviderFactory
                {
                    CacheSignatureProviders = false
                }
            };

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var claims = handler.ValidateToken(token, validationParameters, out var validatedSecurityToken).Claims.ToArray();
                var user = new User 
                {
                    Id = Convert.ToInt32(claims[0].Value),
                    Email = claims[1].Value,
                    Name = claims[2].Value
                };
                return new Result<User>(user);
            }
            catch(Exception ex)
            {
                return new Result<User>(ex);
            }
        }
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
  }
}