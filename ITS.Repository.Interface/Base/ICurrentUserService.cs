using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Repository.Interface.Base
{
    public interface ICurrentUserService
    {
        public string UserName { get; }
        public string UserId { get; }
        public Guid SiteCustomerId { get; }
        public bool IsAuthenticated { get; }
        public IList<string> Roles { get; set; }
        public string Lang { get; set; }
    }
}
