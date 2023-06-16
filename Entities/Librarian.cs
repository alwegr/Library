namespace Library.Entities
{
    public class Librarian
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Middle { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        //многие к одному
        public ICollection<Card> Cards { get; set; }
    }
}
