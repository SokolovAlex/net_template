using System;
using System.ComponentModel.DataAnnotations.Schema;
using App.DAL.Entities.Base;

namespace App.DAL.Entities.News
{
    [Table("News")]
    public class NewsEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }
        public bool IsPublished { get; set; }
    }
}
