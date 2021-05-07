using System.Collections.Generic;
using AspNet.Template.Domain.ViewModels;
using AspNet.Template.Shared.Utils;
using Microsoft.IdentityModel.Tokens;

namespace AspNet.Template.Application.Interfaces
{
    public interface IJwkCredentialsService
    {
        Result<IEnumerable<JwksViewModel>> GetJWK();
    }
}