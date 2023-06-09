﻿using Microsoft.EntityFrameworkCore;
using xCore.Contexts;
using xCore.Interfaces;
using xCore.Models.Entities;

namespace xCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DataContext _context;

        public ArticleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            var authors = _context.Authors.ToList();
            var tags = _context.Tags.ToList();
            return await _context.Articles.Include(a => a.ArticleGroup).Include(x=> x.AuthorArticles).Include(t=>t.ArticleTags).ToListAsync();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _context.Articles.Include(a => a.ArticleGroup).Include(x => x.AuthorArticles).Include(t => t.ArticleTags).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Article>> GetArticlesByGroupId(int groupId)
        {
            return await _context.Articles.Include(a => a.ArticleGroup).Include(x => x.AuthorArticles).Include(t => t.ArticleTags).Where(a => a.ArticleGroupId == groupId).ToListAsync();
        }

        public async Task AddArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArticle(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }

    }
}
