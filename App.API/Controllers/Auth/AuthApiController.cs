using System.Web.Http;
using App.DTO.ApiModels.Responses.User;

namespace App.API.Controllers.Auth
{
    public class AuthApiController : ApiController
    {
        [Route("api/users/{userId}")]
        public UserResponse GetById(int userId)
        {
            return new UserResponse
            {
                Name = "Kirill",
                Surname = "Starodubtsev"
            };
        }
    }
}