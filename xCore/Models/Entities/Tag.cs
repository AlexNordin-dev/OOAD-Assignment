﻿namespace xCore.Models.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
