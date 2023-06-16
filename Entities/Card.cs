namespace Library.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public string DateStarthAsString
        {
            get
            {
                return DateStart.ToString("dd'.'MM'.'yyyy");
            }
        }
        public DateTime DateEnd { get; set; }
        public string DateEndAsString
        {
            get
            {
                return DateEnd.ToString("dd'.'MM'.'yyyy");
            }
        }

        public int BookId { get; set; }
        public Book Books { get; set; }


        public int ReaderId { get; set; }
        public Reader Readers { get; set; }


        public int LibrarianId { get; set; }
        public Librarian Librarians { get; set; }
    }
}
