using xCore.DTOs;
using xCore.Models.Entities;

namespace xCore.Models
{
    public static class ArticleExtensions
    {
        public static ArticleResponse ToArticleResponse(this Article article, IEnumerable<Author> authors, IEnumerable<Tag> tags)
        {
            return new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CreatedAt = article.CreatedAt,
                UpdatedAt = article.UpdatedAt,
                ArticleGroupName = article.ArticleGroup?.Name ?? "",
                AuthorNames = article.AuthorArticles?.Select(aa => authors.FirstOrDefault(a => a.Id == aa.AuthorId)?.Name).ToList() ?? new List<string>(),
                Tags = article.ArticleTags?.Select(at => tags.FirstOrDefault(a => a.Id == at.TagId)?.Name).ToList() ?? new List<string>(),
                //Tags = article.ArticleTags?.Select(at => at.Tag.Name).ToList() ?? new List<string>()
            };
        }


        public static Article ToArticle(this ArticleRequest request)
        {
            var authorArticles = request.AuthorIds.Select(authorId => new AuthorArticle { AuthorId = authorId }).ToList();
            var articleTags = request.TagsIds.Select(TagId => new ArticleTag { TagId = TagId }).ToList();
            var articleGroup = request.ArticleGroupId;
            //var articleTags = request.Tags.Select(tagName => new ArticleTag { Tag = tags.FirstOrDefault(tag => tag.Name == tagName) ?? new Tag { Name = tagName } }).ToList();

            return new Article
            {
                Title = request.Title,
                Content = request.Content,
                CreatedAt = System.DateTime.UtcNow,
                UpdatedAt = System.DateTime.UtcNow,

                AuthorArticles = authorArticles,
                ArticleTags = articleTags,
                ArticleGroupId = articleGroup

            };
        }


        public static void UpdateArticle(this ArticleRequest request, Article article)
        {
            var authorArticles = request.AuthorIds.Select(authorId => new AuthorArticle { AuthorId = authorId }).ToList();
            var articleTags = request.TagsIds.Select(TagId => new ArticleTag { TagId = TagId }).ToList();
            var articleGroup = request.ArticleGroupId;
            article.Title = request.Title;
            article.Content = request.Content;
            article.UpdatedAt = System.DateTime.UtcNow;
            article.ArticleGroupId = request.ArticleGroupId;
            article.AuthorArticles = authorArticles;
            article.ArticleTags = articleTags;
            article.ArticleGroupId = articleGroup;

        }
    }
}
