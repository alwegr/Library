namespace Library.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PablicationYear { get; set; }
        public string PablicationYearAsString
        {
            get
            {
                return PablicationYear.ToString("yyyy");
            }
        }
        public decimal Cost { get; set; }


        //многие ко многим
        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public ICollection<BookGenre> BookGenres { get;set; }


        //многие к одному
        public ICollection<Card> Cards { get;set; }
    }
}
