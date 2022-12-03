using ITS.Repository.Interface.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ITS.WebApi.Helper.Implement
{
    public class CurrentUserService : ICurrentUserService
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("id");
            
            string _SiteCustomerId =  httpContextAccessor.HttpContext?.User?.FindFirstValue("scid");
            SiteCustomerId = string.IsNullOrEmpty(_SiteCustomerId) ? new Guid() : Guid.Parse(_SiteCustomerId);
            IsAuthenticated = UserName != null;
            if (httpContextAccessor.HttpContext != null)
                if (httpContextAccessor.HttpContext.Request.Headers.ContainsKey("Lang"))
                {
                    Microsoft.Extensions.Primitives.StringValues s;
                    if (httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Lang", out s))
                    {
                        this.Lang = s[0];
                    }
                }
        }

        public string UserName { get; }
        public string UserId { get; }
        public Guid SiteCustomerId { get; }
        public bool IsAuthenticated { get; }
        public IList<string> Roles { get; set; }
        public string Lang { get; set; }
    }
}
