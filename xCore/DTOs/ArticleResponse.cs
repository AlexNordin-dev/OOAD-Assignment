using xCore.Models;

namespace xCore.DTOs
{
    public class ArticleResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }       
        public string ArticleGroupName { get; set; }
        public List<string> AuthorNames { get; set; }
        public List<string> Tags { get; set; }
    }
}
