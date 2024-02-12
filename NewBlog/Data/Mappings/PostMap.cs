using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBlog.Models;

namespace NewBlog.Data.Mappings;

public class PostMap : IEntityTypeConfiguration<Post>
{
    private IEntityTypeConfiguration<Post> _entityTypeConfigurationImplementation;
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");//Tabela
        builder.HasKey(x => x.Id);//Chave Primaria
        builder.Property(x => x.Id) //Identity auto-increment
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        //Propriedades
        builder.Property(x => x.Title)
            .IsRequired() //Not Null
            .HasColumnName("Title")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Body)
            .IsRequired() //Not Null
            .HasColumnName("Body")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Summary)
            .IsRequired() //Not Null
            .HasColumnName("Summary")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Slug)
            .IsRequired() //Not Null
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.LastUpdateDate)
            .IsRequired()
            .HasColumnName("LastUpdateDate")
            .HasColumnType("SMALLDATETIME")
            // .HasDefaultValueSql("GETDATE()"); //Funções SQKL que serão executadas
            .HasDefaultValue(DateTime.Now.ToUniversalTime());
        
        builder.HasIndex(x => x.Slug, "IX_User_Slug")
            .IsUnique();

        //Relacionamentos
        builder.HasOne(x => x.Author)
            .WithMany(x=>x.Posts)
            .HasConstraintName("FK_Post_Author")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_Category")
            .OnDelete(DeleteBehavior.ClientCascade);
        
        _entityTypeConfigurationImplementation.Configure(builder);
    }
}