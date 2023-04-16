namespace xCore.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AuthorArticle> AuthorArticles { get; set; }
    }
}
