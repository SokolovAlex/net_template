using System;
using System.ComponentModel.DataAnnotations.Schema;
using App.DAL.Entities.Base;

namespace App.DAL.Entities.Blog
{
    [Table("Blog")]
    public class BlogEntity : BaseEntity
    {
        public int UserId { get; set; }
        public int StatusId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public bool IsPublished { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ReferenceEntity Status { get; set; }
    }
}
