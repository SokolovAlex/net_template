using System;
using System.Collections.Generic;

namespace App.BLL.Abstract.Helpers
{
    public interface IRedisCacheHelper
    {
        T Get<T>(string key);
        IDictionary<string, T> GetAll<T>(IEnumerable<string> keys);
        IEnumerable<string> SearchKeys(string pattern);
        bool Exists(string key);
        bool Add<T>(string key, T model);
        bool Add<T>(string key, T model, DateTimeOffset expiresAt);
        bool AddAll<T>(IList<Tuple<string, T>> items);
        bool Remove(string key);
        void RemoveAll(IEnumerable<string> keys);
    }
}
