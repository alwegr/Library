using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Library.Configuration
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id)
               .HasName("PK_Author_Id");

            builder.Property(author => author.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");

            builder.Property(author => author.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");

            builder.Property(author => author.Middle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");

            builder.Property(author => author.DateOfBirth)
                .IsRequired()
                .HasColumnType("Date");

            builder.Property(author => author.DateOfDeath)
                .IsRequired(false)
                .HasColumnType("Date");


        }
    }
}
