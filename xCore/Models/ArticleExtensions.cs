using xCore.DTOs;
using xCore.Models.Entities;

namespace xCore.Models
{
    public static class ArticleExtensions
    {
        public static ArticleResponse ToArticleResponse(this Article article)
        {
            return new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CreatedAt = article.CreatedAt,
                UpdatedAt = article.UpdatedAt,
                ArticleGroupId = article.ArticleGroupId,
                ArticleGroupName = article.ArticleGroup?.Name ?? "",

            };
        }

        public static Article ToArticle(this ArticleRequest request)
        {
            return new Article
            {
                Title = request.Title,
                Content = request.Content,
                CreatedAt = System.DateTime.UtcNow,
                UpdatedAt = System.DateTime.UtcNow,
                ArticleGroupId = request.ArticleGroupId,
                
            };
        }

        public static void UpdateArticle(this ArticleRequest request, Article article)
        {
            article.Title = request.Title;
            article.Content = request.Content;
            article.UpdatedAt = System.DateTime.UtcNow;
            article.ArticleGroupId = request.ArticleGroupId;
        }
    }
}
