using App.BLL;
using App.BLL.Abstract.Managers.Base;
using App.BLL.Helpers;
using App.DTO.Models.Base;
using App.Web.Filters;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;


namespace App.Web.Areas.Base.Controllers
{
    public class apiUsersController : ApiController
    {
        // GET: api/Default
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            CookieHeaderValue cookie = Request.Headers.GetCookies("x-access-token").FirstOrDefault();

            var sessionHelper = new SessionHelper();
            var user = sessionHelper.GetUser(cookie["x-access-token"].Value);
            FakeAuth.Auth2(user);

            var manager = IoC.Instance.Resolve<IUserManager>();
            return Request.CreateResponse(HttpStatusCode.OK, manager.Repository.GetAll().ToList());
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
