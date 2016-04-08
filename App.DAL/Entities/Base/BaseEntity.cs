using System.ComponentModel.DataAnnotations;

namespace App.DAL.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }
}
