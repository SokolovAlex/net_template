using System;
using System.Collections.Generic;
using System.Linq;
using App.Web.Areas.Auth.Helpers;
using App.DTO.Enums;
using App.BLL.Concrete.Helpers;
using App.BLL.Abstract.Managers.Base;
using App.BLL;
using Autofac;

namespace App.Web.Areas.Auth
{
    public class AuthFactory
    {
        public AuthFactory()
        {
             SettingsHelper.Instance.Init(IoC.Instance.Resolve<IReferenceManager>().Repository.GetByCategoryId((int)BaseEnums.Reference.Category.Settings));
        }

        public SocialHelper GetGoogle() {
            //{ "web":{ "client_id":"117637148027-9bgi2j0ahtl8mrsgjcoipfmerkao7ios.apps.googleusercontent.com","project_id":"auth-sokolov-alex-1985","auth_uri":"https://accounts.google.com/o/oauth2/auth","token_uri":"https://accounts.google.com/o/oauth2/token","auth_provider_x509_cert_url":"https://www.googleapis.com/oauth2/v1/certs","client_secret":"FNoRY2s0O7qII45qzQv0Xw4t"} }
            var clientId = "117637148027-9bgi2j0ahtl8mrsgjcoipfmerkao7ios.apps.googleusercontent.com";
            var secret = "FNoRY2s0O7qII45qzQv0Xw4t";

            return new GoogleHelper(clientId, secret);
        }
    }
}
