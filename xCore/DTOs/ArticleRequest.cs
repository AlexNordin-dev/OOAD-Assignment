namespace xCore.DTOs
{
    public class ArticleRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ArticleGroupId { get; set; }
        public ICollection<int> AuthorIds { get; set; }
        public ICollection<int> TagIds { get; set; }

    }
}
