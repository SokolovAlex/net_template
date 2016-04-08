using System.ComponentModel.DataAnnotations.Schema;
using App.DAL.Entities.Base;

namespace App.DAL.Entities.Photo
{
    [Table("PhotoFile")]
    public class PhotoFileEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
