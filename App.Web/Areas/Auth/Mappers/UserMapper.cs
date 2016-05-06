using App.DTO.Models.Base;
using App.Web.Areas.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Web.Areas.Auth.Mappers
{
    public static class UserMapper
    {
        public static UserModel MapUserFromGoogleProfile(GoogleProfile2 profile) {
            return new UserModel();
        }
    }
}