using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Configuration
{
    public class ReaderEntityTypeConfiguration : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.HasKey(reader => reader.Id)
                .HasName("PK_Reader_Id");

            builder.Property(reader => reader.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");

            builder.Property(reader => reader.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");

            builder.Property(reader => reader.Middle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");

            builder.Property(reader => reader.Login)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");

            builder.Property(reader => reader.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");

            builder.Property(reader => reader.Passport)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar");


           

        }
    }
}
