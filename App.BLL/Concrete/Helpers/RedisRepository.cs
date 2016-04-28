using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using App.BLL.Abstract.Helpers;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;
using StackExchange.Redis.Extensions.Core.Configuration;

namespace App.BLL.Common.Concrete.Helpers
{
    public class RedisRepository<T> : IRedisRepository<T> where T : class
    {
        private NewtonsoftSerializer _serializer { get; set; }
        private StackExchangeRedisCacheClient _client { get; set; }

        private readonly string _tableName;

        public RedisRepository(string host, int database, string tableName)
        {
            _tableName = tableName;
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints =
                {
                    { host, 6379 }
                },
                KeepAlive = 180,
                DefaultVersion = new Version("2.8.5"),
                AllowAdmin = true
            };
            var redis = ConnectionMultiplexer.Connect(configurationOptions);
            _serializer = new NewtonsoftSerializer();
            _client = new StackExchangeRedisCacheClient(redis, _serializer, database);
        }

        private string GetKey(string key)
        {
            return string.Format("urn:{0}:{1}", _tableName, key);
        }

        public string Create(T model, params string[] keys)
        {
            var key = string.Join(":", keys);
            _client.Add(GetKey(key), model);
            return key;
        }

        public List<T> GetByToken(params string[] kkey)
        {
            var key = string.Join(":", kkey);

            var keys = _client.SearchKeys(GetKey(key));

            if (!keys.Any()) return new List<T>();

            return _client.GetAll<T>(keys)
                .Select(x=>x.Value)
                .ToList();
        }

        public bool DeleteByKey(params string[] kkey)
        {
            var key = string.Join(":", kkey);
            var keys = _client.SearchKeys(GetKey(key));
            _client.RemoveAll(keys);
            return true;
        }

        public bool CheckKey(params string[] kkey)
        {
            var key = string.Join(":", kkey);
            var keys = _client.SearchKeys(GetKey(key));
            return keys.Any();
        }

        public void Clear()
        {
            var keys = _client.SearchKeys(string.Format("*"));
            _client.RemoveAll(keys);
        }

        public List<string> GetByElasticToken(params string[] kkey)
        {
            var key = string.Join(":", kkey);
            var keys = _client.SearchKeys(GetKey(key));
            if (!keys.Any()) return new List<string>();

            return _client.GetAll<string>(keys)
              .Select(x => x.Value)
              .ToList();
        }
    }
}
