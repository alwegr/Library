using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Library.Configuration
{
    public class GenreEntityTypeConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(denre => denre.Id)
                .HasName("PK_Genre_Id");

            builder.Property(genre => genre.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar");
        }
    }
}
