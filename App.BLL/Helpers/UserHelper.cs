using App.BLL.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DTO.Models.Base;
using App.DAL.Abstract.Base;
using App.DAL.Concrete.Base;

namespace App.BLL.Helpers
{
    public class UserHelper: IUserHelper
    {
        public UserHelper() {
        }

        public UserModel GetUSerFromGoogleProfile()
        {
            throw new NotImplementedException();
        }

        public int SaveUser(UserModel user)
        {
            var rep = new UserRepository();

            var userId = rep.Save(user);

            rep.Commit();

            return userId;
        }
    }
}
