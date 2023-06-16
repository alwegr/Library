using Library.Entities;
using Microsoft.EntityFrameworkCore;


namespace Library.Date
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Book> BookGenre { get; set; }
        public DbSet<Book> AuthorBook { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Card> Card { get; set; }

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= GORODINEC-A\\SQLEXPRESS; Database= Library; Trusted_Connection=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Library.Entities.AuthorBook> AuthorBook_1 { get; set; } = default!;
    }
}
