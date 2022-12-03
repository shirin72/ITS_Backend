using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Repository.Implements.Base
{
    public interface IJwtFactoryBussiness
    {
        Task<string> GenerateEncodedToken(string userName,ClaimsIdentity identity, string SiteCustomerId);
        ClaimsIdentity GenerateClaimsIdentity(string userName,  string UserRole);
    }
}
