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

        private SessionModel GetSessionUserModel(UserModel user)
        {
            var helper = new HashHelper();
            return new SessionModel
            {
                AssessToken = helper.GetSHA512Hash(helper.GetPassword(16)),
                ExpirationTime = DateTime.Now.AddHours(30),
                RefreshToken = helper.GetSHA512Hash(helper.GetPassword(16)),
                Avatar = user.Avatar,
                DisplayName = user.Name + " " + user.Surname
            };
        }

        public UserModel GetUSerFromGoogleProfile()
        {
            throw new NotImplementedException();
        }

        public int SaveUser(UserModel user)
        {
            var rep = new UserRepository();

            var userDb = rep.Save(user);

            rep.Commit();

            return userDb.Id;
        }

        //public SessionModel SessionCreate(UserModel user)
        //{

        //    var model =
        //        GetSessionUserModel(user);

        //    var redis = IoC.Instance.Resolve<IRedisRepository<UserSessionModel>>(
        //         new NamedParameter("host", AppSettingsHelper.Instance.AppSettings[Enums.AppSettings.RedisHost].Value),
        //         new NamedParameter("database", int.Parse(AppSettingsHelper.Instance.AppSettings[Enums.AppSettings.RedisDb].Value)),
        //         new NamedParameter("tableName", "Session"));

        //    var assessTokenRedis = IoC.Instance.Resolve<IRedisRepository<string>>(
        //        new NamedParameter("host", AppSettingsHelper.Instance.AppSettings[Enums.AppSettings.RedisHost].Value),
        //        new NamedParameter("database", int.Parse(AppSettingsHelper.Instance.AppSettings[Enums.AppSettings.RedisDb].Value)),
        //        new NamedParameter("tableName", "AceesToken"));

        //    var refreshTokenRedis = IoC.Instance.Resolve<IRedisRepository<string>>(
        //        new NamedParameter("host", AppSettingsHelper.Instance.AppSettings[Enums.AppSettings.RedisHost].Value),
        //        new NamedParameter("database", int.Parse(AppSettingsHelper.Instance.AppSettings[Enums.AppSettings.RedisDb].Value)),
        //        new NamedParameter("tableName", "RefreshToken"));


        //    redis.Create(model, model.UserModel.HashId);
        //    assessTokenRedis.Create(model.UserModel.HashId, model.Session.AssessToken);
        //    refreshTokenRedis.Create(model.UserModel.HashId, model.Session.RefreshToken);
        //    return model.Session;
        //    /*assessTokenRedis.Create(token.GetPassword(16), model.UserModel.HashId);
        //    refreshTokenRedis.Create(token.GetPassword(16), model.UserModel.HashId);*/
        //}
    }
}
