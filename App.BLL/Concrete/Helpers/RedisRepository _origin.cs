//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Script.Serialization;
//using App.BLL.Abstract.Helpers;
//using ServiceStack.Redis;
//using ServiceStack.Redis.Generic;
//using StackExchange.Redis;

////ServiceStack
////


//namespace App.BLL.Common.Concrete.Helpers
//{
//    public class RedisRepositoryOrigin<T> : IRedisRepository<T> where T : class
//    {
//        private readonly RedisClient _client;
//        private readonly string _tableName;

//        public RedisRepositoryOrigin(string host, int database, string tableName)
//        {
//            _tableName = tableName;

//            _client = new /*RedisClient*/(new RedisEndpoint()
//            {
//                Host = host,
//                Db = database
//            });

//        }

//        private string GetKey(string key)
//        {
//            return string.Format("urn:{0}:{1}", _tableName, key);
//        }

//        public string Create(T model, params string[] keys)
//        {
//            var key = string.Join(":", keys);
//            IRedisTypedClient<T> redis = _client.As<T>();

//            IRedisList<T> mostSelling = redis.Lists[GetKey(key)];

//            mostSelling.Add(model);
//            return key;
//        }

//        public List<T> GetByToken(params string[] kkey)
//        {
//            IRedisTypedClient<T> redis = _client.As<T>();
//            var key = string.Join(":", kkey);
//            var keys = _client.SearchKeys(GetKey(key));
//            var items = new List<T>();
//            if (!keys.Any()) return items;

//            foreach (var k in keys)
//            {
//                IRedisList<T> mostSelling = redis.Lists[k];
//                items.AddRange(mostSelling);
//            }
//            return items;
//        }

//        public bool DeleteByKey(params string[] kkey)
//        {
//            IRedisTypedClient<T> redis = _client.As<T>();
//            var key = string.Join(":", kkey);
//            var keys = _client.SearchKeys(GetKey(key));

//            foreach (var k in keys)
//            {
//                IRedisList<T> mostSelling = redis.Lists[k];
//                redis.RemoveAllFromList(mostSelling);
//            }
//            return true;
//        }


//        public bool CheckKey(params string[] kkey)
//        {
//            var key = string.Join(":", kkey);
//            var keys = _client.SearchKeys(GetKey(key));
//            return keys.Any();

//        }


//        public void Clear()
//        {
//            IRedisTypedClient<T> redis = _client.As<T>();
//            var keys = _client.SearchKeys(string.Format("*"));
//            foreach (var key in keys)
//            {
//                IRedisList<T> mostSelling = redis.Lists[key];
//                redis.RemoveAllFromList(mostSelling);
//            }

//        }

//        public List<string> GetByElasticToken(params string[] kkey)
//        {
//            IRedisTypedClient<string> redis = _client.As<string>();
//            var key = string.Join(":", kkey);
//            var keys = _client.SearchKeys(GetKey(key));
//            var items = new List<string>();
//            if (!keys.Any()) return items;

//            foreach (var k in keys)
//            {
//                IRedisList<string> mostSelling = redis.Lists[k];
//                items.AddRange(mostSelling);
//            }
//            return items;
//        }
//    }
//}
