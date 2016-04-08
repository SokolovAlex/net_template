using System.Collections.Generic;
using System.Linq;
using App.DTO.Enums;
using App.DTO.Models.Base;

namespace App.BLL.Concrete.Helpers
{
    public class SettingsHelper
    {
        private static SettingsHelper _instance;

        public Dictionary<BaseEnums.Reference.Settings, ReferenceModel> Settings;

        private SettingsHelper()
        {
            Settings = new Dictionary<BaseEnums.Reference.Settings, ReferenceModel>();
        }

        public static SettingsHelper Instance => _instance ?? (_instance = new SettingsHelper());

        public void Init(IEnumerable<ReferenceModel> models)
        {
            Settings = models.ToDictionary(x => (BaseEnums.Reference.Settings)x.Id);
        }
    }
}
