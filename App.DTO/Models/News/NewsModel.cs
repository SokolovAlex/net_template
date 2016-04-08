using System;
using App.DTO.Models.Base;

namespace App.DTO.Models.News
{
    public class NewsModel : BaseModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }
        public bool IsPublished { get; set; }
    }
}
