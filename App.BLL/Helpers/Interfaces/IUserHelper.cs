using App.DTO.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Helpers.Interfaces
{
    interface IUserHelper
    {
        UserModel GetUSerFromGoogleProfile();
    }
}
