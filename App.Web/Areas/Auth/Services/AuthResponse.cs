using App.Web.Areas.Auth.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace App.Web.Areas.Auth.Services
{
    public class AuthResponse
    {
        private string access_token;
        public string Access_token
        {
            get
            {
                // Access token lasts an hour if its expired we get a new one.
                if (DateTime.Now.Subtract(created).Hours > 1)
                {
                    refresh();
                }
                return access_token;
            }
            set { access_token = value; }
        }
        public string refresh_token { get; set; }
        public string clientId { get; set; }
        public string secret { get; set; }
        public string expires_in { get; set; }
        public DateTime created { get; set; }


        /// <summary>
        /// Parse the json response 
        /// //  "{\n  \"access_token\" : \"ya29.kwFUj-la2lATSkrqFlJXBqQjCIZiTg51GYpKt8Me8AJO5JWf0Sx6-0ZWmTpxJjrBrxNS_JzVw969LA\",\n  \"token_type\" : \"Bearer\",\n  \"expires_in\" : 3600,\n  \"refresh_token\" : \"1/ejoPJIyBAhPHRXQ7pHLxJX2VfDBRz29hqS_i5DuC1cQ\"\n}"
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static AuthResponse get(string response)
        {
            AuthResponse result = JsonConvert.DeserializeObject<AuthResponse>(response);
            result.created = DateTime.Now;   // DateTime.Now.Add(new TimeSpan(-2, 0, 0)); //For testing force refresh.
            return result;
        }

        public void refresh()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");

            string postData = string.Format("client_id={0}&client_secret={1}&refresh_token={2}&grant_type=refresh_token", this.clientId, this.secret, this.refresh_token);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var refreshResponse = AuthResponse.get(responseString);
            this.access_token = refreshResponse.access_token;
            this.created = DateTime.Now;
        }

        public GoogleProfile GetProfileInfo()
        {
            var query = String.Format("https://www.googleapis.com/plus/v1/people/me?key={0}", access_token);
            var request = (HttpWebRequest)WebRequest.Create(query);

            request.ContentType = "application/x-www-form-urlencoded";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

           var profile = JsonConvert.DeserializeObject<GoogleProfile>(responseString);

            return profile;
        }

        public GoogleProfile2 GetProfileInfo2()
        {
            var ub = new UriBuilder("https://www.googleapis.com/oauth2/v1/userinfo?alt=json");
            var httpValueCollection = HttpUtility.ParseQueryString(ub.Query);

            httpValueCollection.Add("access_token", access_token);

            ub.Query = httpValueCollection.ToString();
            var request = WebRequest.Create(ub.Uri.ToString());
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var profile = JsonConvert.DeserializeObject<GoogleProfile2>(responseString);

            return profile;
        }

        public static AuthResponse Exchange(string authCode, string clientid, string secret, string redirectURI)
        {

            var request = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");

            string postData = string.Format("code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type=authorization_code", authCode, clientid, secret, redirectURI);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var x = AuthResponse.get(responseString);

            x.clientId = clientid;
            x.secret = secret;

            return x;
        }

        public static Uri GetAutenticationURI(string clientId, string redirectUri)
        {
            string scopes = "https://www.googleapis.com/auth/plus.login email";
            var conf = ConfigurationManager.AppSettings;

            if (string.IsNullOrEmpty(redirectUri))
            {
                redirectUri = conf["CallbackGoogle"];
            }
            string oauth = string.Format("https://accounts.google.com/o/oauth2/auth?client_id={0}&redirect_uri={1}&scope={2}&response_type=code", clientId, redirectUri, scopes);
            return new Uri(oauth);
        }
    }
}