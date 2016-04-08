using System.Collections.Generic;
using System.Web.Http;
using App.DTO.Models.Base;

namespace App.API.Controllers.Base
{
    public class BaseApiController : ApiController
    {
        public IEnumerable<UserModel> GetAllUsers()
        {
            return new List<UserModel>
            {
                new UserModel { Id = 1, Name = "Kirill" },
                new UserModel { Id = 2, Name = "Sergey" }
            };
        }
    }
}
