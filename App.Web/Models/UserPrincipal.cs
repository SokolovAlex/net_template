using App.DTO.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace App.Web.Models
{
    public class UserPrincipal : GenericPrincipal
    {
        public UserPrincipal(IIdentity identity, string[] roles)
            : base(identity, roles)
        {
        }
        public UserSessionModel UserDetails { get; set; }
    }
}