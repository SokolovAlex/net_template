using System.ComponentModel.DataAnnotations;

namespace App.DTO.ViewModels.Base.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}