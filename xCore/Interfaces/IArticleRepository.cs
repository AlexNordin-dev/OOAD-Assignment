using xCore.Models.Entities;

namespace xCore.Interfaces
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticles();
        Task<Article> GetArticleById(int id);
        Task<IEnumerable<Article>> GetArticlesByGroupId(int groupId);
        Task AddArticle(Article article);
        Task UpdateArticle(Article article);
        Task DeleteArticle(int id);
    }
}
