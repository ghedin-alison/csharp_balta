using Microsoft.EntityFrameworkCore;
using NewBlog.Models;

namespace NewBlog.Data;

public class NewBlogDataContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Role> Roles { get; set; } 
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=Blog;User ID=sa;password=1q2w3e4r@#$;Encrypt=False");
}