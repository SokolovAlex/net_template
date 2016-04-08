using System.Collections.Generic;
using App.DTO.Models.Base;

namespace App.DTO.ViewModels.Base.Home
{
    public class HomeViewModel
    {
        public IEnumerable<UserModel> Users { get; set; }
    }
}