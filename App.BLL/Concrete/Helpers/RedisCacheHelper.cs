using System;
using System.Collections.Generic;
using App.BLL.Abstract.Helpers;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace App.BLL.Concrete.Helpers
{
    public class RedisCacheHelper : IRedisCacheHelper
    {
        private NewtonsoftSerializer _serializer { get; set; }
        private StackExchangeRedisCacheClient _cacheClient { get; set; }

        public RedisCacheHelper()
        {
            _serializer = new NewtonsoftSerializer();
            _cacheClient = new StackExchangeRedisCacheClient(_serializer);
        }

        #region Get

        public T Get<T>(string key)
        {
            return _cacheClient.Get<T>(key);
        }

        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            return _cacheClient.GetAll<T>(keys);
        }

        public IEnumerable<string> SearchKeys(string pattern)
        {
            return _cacheClient.SearchKeys(pattern);
        }

        public bool Exists(string key)
        {
            return _cacheClient.Exists(key);
        }

        #endregion

        #region Set

        public bool Add<T>(string key, T model)
        {
            return _cacheClient.Add(key, model);
        }

        public bool Add<T>(string key, T model, DateTimeOffset expiresAt)
        {
            return _cacheClient.Add(key, model, expiresAt);
        }

        public bool AddAll<T>(IList<Tuple<string, T>> items)
        {
            return _cacheClient.AddAll(items);
        }

        public bool Remove(string key)
        {
            return _cacheClient.Remove(key);
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            _cacheClient.RemoveAll(keys);
        }

        #endregion
    }
}
