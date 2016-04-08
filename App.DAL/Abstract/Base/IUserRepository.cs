using System.Linq;
using App.DTO.Models.Base;

namespace App.DAL.Abstract.Base
{
    public interface IUserRepository
    {
        IQueryable<UserModel> GetBy();

        UserModel GetById(int id);
        IQueryable<UserModel> GetAll();
    }
}
