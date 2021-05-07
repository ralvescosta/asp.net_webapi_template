using System.Collections.Generic;
using AspNet.Template.Application.Interfaces;
using AspNet.Template.Domain.ViewModels;
using AspNet.Template.Shared.Utils;
using Microsoft.IdentityModel.Tokens;

namespace AspNet.Template.Application.Services
{
    public class JwkCredentialsService : IJwkCredentialsService
    {
        private readonly ITokenManager _tokenManager;
        public JwkCredentialsService(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public Result<IEnumerable<JwksViewModel>> GetJWK()
        {
            var jwks = _tokenManager.GetJWK();

            return jwks.Match<Result<IEnumerable<JwksViewModel>>>(
                success => new Result<IEnumerable<JwksViewModel>>(
                    new List<JwksViewModel>
                    {
                        new JwksViewModel 
                        {
                            Kty = success.Kty,
                            E = success.E,
                            Use = success.Use,
                            Alg = "RS256",
                            N = success.N,
                            Kid = success.Kid
                        }
                    }),
                failure => new Result<IEnumerable<JwksViewModel>>(failure)
            );
        }
        
    }
}