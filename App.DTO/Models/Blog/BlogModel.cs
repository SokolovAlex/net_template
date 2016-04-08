using System;
using App.DTO.Models.Base;

namespace App.DTO.Models.Blog
{
    public class BlogModel : BaseModel
    {
        public int UserId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        public bool IsPublished { get; set; }

        public UserModel User { get; set; }
    }
}
