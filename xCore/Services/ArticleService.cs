using xCore.DTOs;
using xCore.Interfaces;
using xCore.Models;
using xCore.Models.Entities;
using xCore.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace xCore.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly AuthorsRepository _authorRepository;
        private readonly TagsRepository _tagsRepository;

        public ArticleService(IArticleRepository articleRepository, AuthorsRepository authorRepository, TagsRepository tagsRepository)
        {
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
            _tagsRepository = tagsRepository;
        }

        public async Task<IEnumerable<ArticleResponse>> GetAllArticles()
        {
            var tags= await _tagsRepository.GetAllTags();
            var authors = await _authorRepository.GetAllAuthors();
            var articles = await _articleRepository.GetAllArticles();
            return articles.Select(a => a.ToArticleResponse(authors, tags));
        }

        public async Task<ArticleResponse> GetArticleById(int id)
        {
            var tags = await _tagsRepository.GetAllTags();
            var authors = await _authorRepository.GetAllAuthors();
            var article = await _articleRepository.GetArticleById(id);
            return article?.ToArticleResponse(authors, tags);
        }

        public async Task<IEnumerable<ArticleResponse>> GetArticlesByGroupId(int groupId)
        {
            var tags = await _tagsRepository.GetAllTags();
            var authors = await _authorRepository.GetAllAuthors();
            var articles = await _articleRepository.GetArticlesByGroupId(groupId);
            return articles.Select(a => a.ToArticleResponse(authors, tags));
        }

        public async Task<ArticleResponse> CreateArticle(ArticleRequest articleRequest)
        {
            var tags = await _tagsRepository.GetAllTags();
            var authors = await _authorRepository.GetAllAuthors();
            var article = articleRequest.ToArticle();
            await _articleRepository.AddArticle(article);
            return article.ToArticleResponse(authors, tags);
        }

        public async Task<ArticleResponse> UpdateArticle(int id, ArticleRequest articleRequest)
        {
            var tags = await _tagsRepository.GetAllTags();
            var authors = await _authorRepository.GetAllAuthors();
            var article = await _articleRepository.GetArticleById(id);
            if (article == null) return null;

            articleRequest.UpdateArticle(article);
            await _articleRepository.UpdateArticle(article);

            return article.ToArticleResponse(authors, tags);
        }

        public async Task DeleteArticle(int id)
        {
            await _articleRepository.DeleteArticle(id);
        }

    }
}
