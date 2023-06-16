namespace Library.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Middle { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DateOfBirthAsString
        {
            get
            {
                return DateOfBirth.ToString("dd'.'MM'.'yyyy");
            }
        }

        public DateTime? DateOfDeath { get; set; }

        public string DateOfDeathAsString
        {
            get
            {
                if (DateOfDeath.HasValue)
                {
                    return Convert.ToDateTime(DateOfDeath).ToString("dd'.'MM'.'yyyy");
                }
                else
                {
                    return "-";
                }

            }
        }

        //многие ко многим
        public ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
