using System.ComponentModel.DataAnnotations.Schema;

namespace App.DAL.Entities.Base
{
    [Table("User")]
    public partial class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
