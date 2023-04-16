using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xCore.DTOs;
using xCore.Interfaces;

namespace xCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleResponse>>> GetAllArticles()
        {
            var articles = await _articleService.GetAllArticles();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleResponse>> GetArticleById(int id)
        {
            var article = await _articleService.GetArticleById(id);
            if (article == null) return NotFound();
            return Ok(article);
        }

        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<ArticleResponse>>> GetArticlesByGroupId(int groupId)
        {
            var articles = await _articleService.GetArticlesByGroupId(groupId);
            return Ok(articles);
        }

        [HttpPost]
        public async Task<ActionResult<ArticleResponse>> CreateArticle([FromBody] ArticleRequest articleRequest)
        {
            var article = await _articleService.CreateArticle(articleRequest);
            return CreatedAtAction(nameof(GetArticleById), new { id = article.Id }, article);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArticleResponse>> UpdateArticle(int id, [FromBody] ArticleRequest articleRequest)
        {
            var article = await _articleService.UpdateArticle(id, articleRequest);
            if (article == null) return NotFound();
            return Ok(article);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleService.DeleteArticle(id);
            return NoContent();
        }
    }
}
