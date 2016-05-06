using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Web.Areas.Auth.Models
{
    public class ProfileEmail {
        public string value { get; set; }
        public string type { get; set; }
    }

    public class ProfileName
    {
        public string familyName { get; set; }
        public string givenName { get; set; }
    }

    public class ProfileImage
    {
        public string url { get; set; }
        public bool isDefault { get; set; }
    }

    public class GoogleProfile
    {
        public string kind { get; set; } //"plus#person",
        public string gender { get; set; } // "male",
        public List<ProfileEmail> emails { get; set; }
        public string objectType { get; set; }
        public string id { get; set; }
        public string displayName { get; set; }
        public string url { get; set; }
        public ProfileImage image { get; set; }
        public ProfileName name { get; set; }
        public string language { get; set; }
    }

    public class GoogleProfile2
    {
        public string email { get; set; }
        public string picture { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public bool verified_email { get; set; }
        public string language { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
    }
}