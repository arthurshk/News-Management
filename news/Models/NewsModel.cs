using System.ComponentModel.DataAnnotations;

namespace news.Models
{
    public class NewsModel
    {
        [Key]
        public int NewsId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public byte[]? ImageDataIMG { get; set; }
    }
}
