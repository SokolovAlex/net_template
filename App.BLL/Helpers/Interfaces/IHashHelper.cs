using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Helpers.Interfaces
{
    public interface IHashHelper
    {
        #region Abstract Methods

        string GetMd5Hash(string input);

        string GetSHA256Hash(string input);

        string GetSHA512Hash(string input);

        string GetSalt();

        string GetHash();

        string GetPassword(int length = 4);

        string GetSaltPassword(string password, string salt);

        #endregion
    }
}
