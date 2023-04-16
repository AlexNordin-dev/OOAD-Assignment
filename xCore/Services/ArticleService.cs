using xCore.DTOs;
using xCore.Interfaces;
using xCore.Models;
using xCore.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace xCore.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
       
        public async Task<IEnumerable<ArticleResponse>> GetAllArticles()
        {
            var articles = await _articleRepository.GetAllArticles();
            return articles.Select(a => a.ToArticleResponse());
        }

        public async Task<ArticleResponse> GetArticleById(int id)
        {
            var article = await _articleRepository.GetArticleById(id);
            return article?.ToArticleResponse();
        }

        public async Task<IEnumerable<ArticleResponse>> GetArticlesByGroupId(int groupId)
        {
            var articles = await _articleRepository.GetArticlesByGroupId(groupId);
            return articles.Select(a => a.ToArticleResponse());
        }

        public async Task<ArticleResponse> CreateArticle(ArticleRequest articleRequest)
        {
            var article = articleRequest.ToArticle();
            await _articleRepository.AddArticle(article);
            return article.ToArticleResponse();
        }

        public async Task<ArticleResponse> UpdateArticle(int id, ArticleRequest articleRequest)
        {
            var article = await _articleRepository.GetArticleById(id);
            if (article == null) return null;

            articleRequest.UpdateArticle(article);
            await _articleRepository.UpdateArticle(article);

            return article.ToArticleResponse();
        }

        public async Task DeleteArticle(int id)
        {
            await _articleRepository.DeleteArticle(id);
        }

    }
}
