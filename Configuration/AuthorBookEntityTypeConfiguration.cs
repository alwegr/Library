using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Configuration
{
    public class AuthorBookEntityTypeConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(cs => new { cs.AuthorId, cs.BookId })
                .HasName("PK_AuthorBook_AuthorId_BookId");


            builder.HasOne(authorBook => authorBook.Author)
                .WithMany(author => author.AuthorBooks)
                .HasForeignKey(authorBook => authorBook.AuthorId)
                .HasConstraintName("FK_AuthorBook_AuthorId_Author_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(authorBook => authorBook.Book)
               .WithMany(book => book.AuthorBooks)
               .HasForeignKey(book => book.BookId)
               .HasConstraintName("FK_AuthorBook_BookId_Book_Id")
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
