using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Library.Configuration
{
    public class LibrarianEntityTypeConfiguration : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder.HasKey(librarian => librarian.Id)
               .HasName("PK_Librarian_Id");

            builder.Property(librarian => librarian.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(librarian => librarian.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(librarian => librarian.Middle)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(librarian => librarian.Login)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(librarian => librarian.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");
        }
    }
}
