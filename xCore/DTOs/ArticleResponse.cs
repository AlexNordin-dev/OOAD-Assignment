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
        public int ArticleGroupId { get; set; }
        public string ArticleGroupName { get; set; }
        public ICollection<string> AuthorNames { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
