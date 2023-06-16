using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Configuration
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id)
                .HasName("PK_Book_Id");

            builder.Property(book => book.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(book => book.Author)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(book => book.Publisher)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");

            builder.Property(book => book.PablicationYear)
                .IsRequired()
                .HasColumnType("Date");

            builder.Property(book => book.Cost)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("money");
        }
    }
}
