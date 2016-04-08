using System;
using System.Web;
using App.DTO;

namespace App.BLL.Concrete.Helpers
{
    public static class UserHelper
    {
        public static bool IsAuthenticated()
        {
            //var userCookie = HttpContext.Current.Request.Cookies.Get(SettingsHelper.Instance.Settings[BaseEnums.Settings.UserCookieName].Value);
            //var userCookiePrefix = SettingsHelper.Instance.Settings[BaseEnums.Settings.UserCookiePrefix].Value;

            //if (userCookie != null && userCookie.Value.Contains(userCookiePrefix))
            //{
            //    var sessionGuid = Guid.Parse(userCookie.Value.Replace(userCookiePrefix, string.Empty));
            //}

            return false;
        }
    }
}
