using App.BLL.Abstract.Helpers;
using App.BLL.Helpers.Interfaces;
using App.DTO.Models.Base;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Helpers
{
    public class SessionHelper
    {
        private UserSessionModel GetSessionUserModel(UserModel user)
        {
            var helper = IoC.Instance.Resolve<IHashHelper>();
            return new UserSessionModel
            {
                UserModel = user,
                Session = new SessionModel()
                {
                    AssessToken = helper.GetSHA512Hash(helper.GetPassword(16)),
                    ExpirationTime = DateTime.Now.AddHours(30),
                    RefreshToken = helper.GetSHA512Hash(helper.GetPassword(16)),
                    Avatar = user.Avatar,
                    DisplayName = user.Name + " " + user.Nickname,
                    UserId = user.Id.ToString()
                }
            };
        }

        public SessionModel SessionCreate(UserModel user)
        {
            var model = GetSessionUserModel(user);

            var redis = IoC.Instance.Resolve<IRedisRepository<UserSessionModel>>(
                 new NamedParameter("host", "localhost"),
                 new NamedParameter("database", 1),
                 new NamedParameter("tableName", "Session"));

            var assessTokenRedis = IoC.Instance.Resolve<IRedisRepository<string>>(
                new NamedParameter("host", "localhost"),
                new NamedParameter("database", 1),
                new NamedParameter("tableName", "AceesToken"));

            redis.Create(model, model.UserModel.HashId);
            assessTokenRedis.Create(model.UserModel.HashId, model.Session.AssessToken);
            return model.Session;
        }

        public UserSessionModel GetUser(string accessToken)
        {
            var redis = IoC.Instance.Resolve<IRedisRepository<string>>(
                new NamedParameter("host", "localhost"),
                new NamedParameter("database", 1),
                new NamedParameter("tableName", "AceesToken"));
            var hash = redis.GetByToken(accessToken);

            if (hash.Any())
            {
                var session = IoC.Instance.Resolve<IRedisRepository<UserSessionModel>>(
                    new NamedParameter("host", "localhost"),
                    new NamedParameter("database", 1),
                    new NamedParameter("tableName", "Session"));
                var model = session.GetByToken(hash.First());
                return model.All(s => s.Session.ExpirationTime <= DateTime.Now) ? null : session.GetByToken(hash.First()).First();
            }
            return null;
        }
    }
}
