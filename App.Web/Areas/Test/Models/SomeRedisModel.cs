using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Web.Areas.Test.Models
{
    public class SomeRedisModel
    {
        public int Id {get; set;}

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        public string Hash { get; set; }

        public SomeRedisModel ChildModel { get; set; }
    }
}