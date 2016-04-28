using System.Collections.Generic;

namespace App.BLL.Abstract.Helpers
{
    public interface IRedisRepository<T> 
    {
        string Create(T model, params string[] key);

        List<T> GetByToken(params string[] k);

        bool DeleteByKey(params string[] key);

        bool CheckKey(params string[] kkey);

        void Clear();

        List<string> GetByElasticToken(params string[] kkey);
    }
}
