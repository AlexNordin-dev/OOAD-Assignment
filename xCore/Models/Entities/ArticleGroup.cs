namespace xCore.Models.Entities
{
    public class ArticleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
