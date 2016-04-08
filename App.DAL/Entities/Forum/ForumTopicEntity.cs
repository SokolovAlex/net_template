using System.ComponentModel.DataAnnotations.Schema;
using App.DAL.Entities.Base;

namespace App.DAL.Entities.Forum
{
    [Table("ForumTopic")]
    public class ForumTopicEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
