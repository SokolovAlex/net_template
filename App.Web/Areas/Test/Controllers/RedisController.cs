using App.BLL.Abstract.Helpers;
using App.BLL.Common.Concrete.Helpers;
using App.Web.Areas.Test.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Areas.Test.Controllers
{
    public class RedisController : Controller
    {
        private IRedisRepository<SomeRedisModel> repository;

        private SomeRedisModel model { get; set; }

        public RedisController() {
            repository = new RedisRepository<SomeRedisModel>("127.0.0.1", 0, "test_redis");

            var now = DateTime.Now;
            var tommorow = now.AddDays(1);

            model = new SomeRedisModel
            {
                CreateDate = now,
                Id = now.Minute,
                Hash = now.DayOfWeek.ToString(),
                IsActive = true,
                ChildModel = new SomeRedisModel {
                    CreateDate = tommorow,
                    Id = tommorow.Minute,
                    Hash = tommorow.DayOfWeek.ToString(),
                    IsActive = true
                }
            };
        }

        // GET: Test/Redis
        public ActionResult Index()
        {
            return View();
        }

        public string Save(TestRedisRequest req)
        {
            var params_ = req.GetParams();

            repository.Create(model, params_);

            return JsonConvert.SerializeObject(new { isError = false });
        }

        public string Get(TestRedisRequest req)
        {
            var params_ = req.GetParams();

            var models = repository.GetByToken(params_);

            return JsonConvert.SerializeObject(models);
        }

        public string Delete(TestRedisRequest req)
        {
            var params_ = req.GetParams();

            var models = repository.DeleteByKey(params_);

            return JsonConvert.SerializeObject(new { isError = false });
        }
    }
}