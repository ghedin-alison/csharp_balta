using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBlog.Models;

namespace NewBlog.Data.Mappings;

public class CategoryMap: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //Tabela
        builder.ToTable("Category");
        //Chave primária
        builder.HasKey(x => x.Id);
        //Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(); //PRIMARY KEY IDENTITY(1,1) 
        
        //Propriedades
        builder.Property(x => x.Name)
            .IsRequired() //Not Null
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Slug)
            .IsRequired() //Not Null
            .HasColumnName("Slug")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        //Indices
        builder.HasIndex(x => x.Slug, "IX_Category_Slug")
            .IsUnique();
        
    }
}