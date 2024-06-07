using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Summary { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;
        public string Slug { get; set; } = String.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Category Category { get; set; } = null!;
        public User Author { get; set; } = null!;

        public List<Tag> Tags { get; set; } = null!;
    }
}