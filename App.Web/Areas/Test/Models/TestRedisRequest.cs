
using System.Collections.Generic;
using System.Linq;

namespace App.Web.Areas.Test.Models
{
    public class TestRedisRequest
    {
        public string Keypart1 { get; set; }

        public string Keypart2 { get; set; }

        public string Keypart3 { get; set; }

        public string[] GetParams() {

            var res = new List<string>() {
                this.Keypart1,
                this.Keypart2,
                this.Keypart3
            };
            return res.Where(x => x != null).ToArray();
        }
    }
}