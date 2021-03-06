﻿namespace App.DTO.Models.Base
{
    public partial class UserModel : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Salt { get; set; }
        public string Avatar { get; set; }
        public string HashId { get; set; }
    }
}
