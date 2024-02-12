using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBlog.Models;

namespace NewBlog.Data.Mappings;

public class UserMap: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");//Tabela
        builder.HasKey(x => x.Id);//Chave Primaria
        builder.Property(x => x.Id) //Identity auto-increment
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        //Propriedades
        builder.Property(x => x.Name)
            .IsRequired() //Not Null
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Slug)
            .IsRequired() //Not Null
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Bio)
            .IsRequired() //Not Null
            .HasColumnName("Bio")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Email)
            .IsRequired() //Not Null
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Image)
            .IsRequired() //Not Null
            .HasColumnName("Image")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.PasswordHash)
            .IsRequired() //Not Null
            .HasColumnName("PasswordHash")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.HasIndex(x => x.Slug, "IX_User_Slug")
            .IsUnique();

        builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                role => role
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .HasConstraintName("FK_UserRole_RoleId")
                    .OnDelete(DeleteBehavior.Cascade),
                user => user
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_UserRole_UserId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}