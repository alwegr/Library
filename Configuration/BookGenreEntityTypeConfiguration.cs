using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Configuration
{
    public class BookGenreEntityTypeConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasKey(cs => new { cs.BookId, cs.GenreId })
               .HasName("PK_BookGenre_BookId_GenreId");


            builder.HasOne(bookGenre => bookGenre.Book)
                .WithMany(book => book.BookGenres)
                .HasForeignKey(bookGenre => bookGenre.BookId)
                .HasConstraintName("FK_BookGenre_BookId_Book_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(bookGenre => bookGenre.Genre)
               .WithMany(genre => genre.BookGenres)
               .HasForeignKey(bookGenre => bookGenre.GenreId)
               .HasConstraintName("FK_BookGenre_GenreId_Genre_Id")
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
