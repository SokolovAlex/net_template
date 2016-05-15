using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DTO.Models.Base
{
    public class SessionModel
    {

        public string AssessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationTime { get; set; }

        public string DisplayName { get; set; }

        public string Avatar { get; set; }

        public string UserId { get; set; }
    }


}
