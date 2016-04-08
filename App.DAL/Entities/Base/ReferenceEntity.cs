using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.DAL.Entities.Base
{
    [Table("Reference")]
    public class ReferenceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int? ValueInt { get; set; }
        public bool IsActive { get; set; }

        public virtual CategoryEntity Category { get; set; }
    }
}
