using Azure;
using System.Text.RegularExpressions;

namespace xCore.Models.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int ArticleGroupId { get; set; }
        public ArticleGroup? ArticleGroup { get; set; }

        public ICollection<AuthorArticle> AuthorArticles { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
