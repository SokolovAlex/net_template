using App.BLL.Helpers;
using App.DTO.Models.Base;
using App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace App.Web.Filters
{
    public class FakeAuth
    {
        public static bool Auth(HttpContextBase actionContext) {
            IEnumerable<string> tokens = actionContext.Request.Headers.GetValues("X-ACCESS-TOKEN");
            if (tokens == null || !tokens.Any()) return false;

            var helper = new SessionHelper();
            var user = helper.GetUser(tokens.First());
            if (user != null)
            {
                var principal = new UserPrincipal(new GenericIdentity(tokens.First()), new string[0])
                {
                    UserDetails = user
                };
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
                return true;
            }
            return false;

        }

        public static bool Auth2(UserSessionModel model)
        {
            if (model != null)
            {
                var principal = new UserPrincipal(new GenericIdentity(model.Session.AssessToken), new string[0])
                {
                    UserDetails = model
                };
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;
                return true;
            }
            return false;

        }
    }
}