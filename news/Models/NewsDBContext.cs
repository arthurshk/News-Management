using Microsoft.EntityFrameworkCore;

namespace news.Models
{
    public class NewsDBContext : DbContext
    {
        public DbSet<NewsModel> News { get; set; }
        public NewsDBContext(DbContextOptions<NewsDBContext> options) : base(options)
        {
            
        }
    }
}
