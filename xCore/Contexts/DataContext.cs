using Microsoft.EntityFrameworkCore;
using xCore.Models.Entities;

namespace xCore.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AuthorArticle> AuthorArticles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorArticle>()
                .HasKey(aa => new { aa.AuthorId, aa.ArticleId });

            modelBuilder.Entity<AuthorArticle>()
                .HasOne(aa => aa.Author)
                .WithMany(a => a.AuthorArticles)
                .HasForeignKey(aa => aa.AuthorId);

            modelBuilder.Entity<AuthorArticle>()
                .HasOne(aa => aa.Article)
                .WithMany(a => a.AuthorArticles)
                .HasForeignKey(aa => aa.ArticleId);

            modelBuilder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });

            modelBuilder.Entity<ArticleTag>()
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticleTags)
                .HasForeignKey(at => at.ArticleId);

            modelBuilder.Entity<ArticleTag>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.ArticleTags)
                .HasForeignKey(at => at.TagId);
        }

    }
}
