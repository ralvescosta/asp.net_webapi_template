using System;
using AspNet.Template.Domain.Entities;
using AspNet.Template.Shared.Utils;
using Microsoft.IdentityModel.Tokens;

namespace AspNet.Template.Application.Interfaces
{
    public interface ITokenManager
    {
        Result<string> GenerateToken(User user, string audience, DateTime expireDate);

        Result<User> VerifyToken(string token, string audience);

        Result<JsonWebKey> GetJWK();
    }
}