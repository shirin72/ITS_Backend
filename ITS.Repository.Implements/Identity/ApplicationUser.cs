using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Repository.Implements.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string SiteCustomerId { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
