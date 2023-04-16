using xCore.DTOs;

namespace xCore.Interfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleResponse>> GetAllArticles();
        Task<ArticleResponse> GetArticleById(int id);
        Task<IEnumerable<ArticleResponse>> GetArticlesByGroupId(int groupId);
        Task<ArticleResponse> CreateArticle(ArticleRequest articleRequest);
        Task<ArticleResponse> UpdateArticle(int id, ArticleRequest articleRequest);
        Task DeleteArticle(int id);
    }
}
