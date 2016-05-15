using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO.Models.Base
{
    public class UserSessionModel
    {

        public KeyValuePair<int, KeyValuePair<int, KeyValuePair<int, bool>[]>[]>[] SystemAccess
        {
            get;
            set;
        }

        public UserModel UserModel
        {
            get;
            set;
        }

        public SessionModel Session { get; set; }
    }
}
