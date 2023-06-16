using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Configuration
{
    public class CardEntityTypeConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(card => card.Id)
                .HasName("PK_Card_Id");

            builder.Property(card => card.DateStart)
                .IsRequired()
                .HasColumnType("Date");

            builder.Property(card => card.DateEnd)
                .IsRequired()
                .HasColumnType("Date");

            builder.HasOne(card => card.Books)
               .WithMany(book => book.Cards)
               .HasForeignKey(card => card.BookId)
               .HasConstraintName("FK_Card_BookId_Book_Id")
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(card => card.Readers)
              .WithMany(reader => reader.Cards)
              .HasForeignKey(card => card.ReaderId)
              .HasConstraintName("FK_Card_ReaderId_Reader_Id")
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(card => card.Librarians)
              .WithMany(librarian => librarian.Cards)
              .HasForeignKey(card => card.LibrarianId)
              .HasConstraintName("FK_Card_LibrarianId_Librarian_Id")
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
