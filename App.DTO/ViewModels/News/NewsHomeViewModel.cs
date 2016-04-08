using System.Collections.Generic;
using App.DTO.Models.News;

namespace App.DTO.ViewModels.News
{
    public class NewsHomeViewModel
    {
        public int Total { get; set; }
        public IEnumerable<NewsModel> News { get; set; }
    }
}
