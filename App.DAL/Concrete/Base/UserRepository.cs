using System.Linq;
using App.DAL.Abstract.Base;
using App.DAL.Entities.Base;
using App.DTO.Models.Base;

namespace App.DAL.Concrete.Base
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public static UserModel MapToModel(UserEntity x)
        {
            var model = new UserModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Email = x.Email,
                Password = x.Password,
                Name = x.Name,
                Salt = x.Salt,
                Surname = x.Surname
            };

            return model;
        }

        public IQueryable<UserModel> GetBy()
        {
            return Context.User.Select(x => new UserModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Email = x.Email,
                Password = x.Password,
                Name = x.Name,
                Salt = x.Salt,
                Surname = x.Surname
            });
        }

        public UserModel GetById(int id)
        {
            return GetBy().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<UserModel> GetAll()
        {
            return GetBy().Where(x => x.IsActive).OrderBy(x => x.Name);
        }

        public UserEntity Save(UserModel model)
        {
            var dbuser = Context.User.FirstOrDefault(x => x.Email == model.Email);

            if (dbuser == null) {

                var entity = new UserEntity
                {
                    Id = model.Id,
                    IsActive = model.IsActive,
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Surname = model.Surname,
                    Salt = model.Salt,
                    Nickname = model.Email
                };

                Context.User.Add(entity);

                return entity;
            }

            return dbuser;
        }
    }
}
