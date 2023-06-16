namespace Library.Entities
{
    public class Reader
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Middle { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public int CardReaderId { get; set; }


        //многие к одному
        public ICollection<Card>  Cards { get; set; }

    }
}
