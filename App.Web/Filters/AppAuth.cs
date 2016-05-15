using App.BLL;
using App.BLL.Helpers;
using App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace App.Web.Filters
{
    public class ExAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            IEnumerable<string> tokens;
            actionContext.Request.Headers.TryGetValues("X-ACCESS-TOKEN", out tokens);
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

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
            //var errors =
            //JObject.FromObject(new
            //{
            //    code = RequestResult.ExpirateToken,
            //    errors = new[]
            //        {
            //        new ErrorModel
            //        {
            //            errorCode = RequestResult.ExpirateToken.Code.Code,
            //            errorMessage =  RequestResult.ExpirateToken.Description,
            //            errorField = "accessToken"
            //        }
            //        }
            //});
            //actionContext.Response = actionContext.Request.CreateResponse<JObject>(RequestResult.ExpirateToken.Code.HttpCode, errors)/*;*/
        }
    }
}