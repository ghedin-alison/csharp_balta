using System.Collections.Generic;

namespace Blog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Slug { get; set; } = String.Empty;
        
        public IList<Post> Posts { get; set; } = null!;
    }
}