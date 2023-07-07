namespace BookshelfMVC.Domain.Model
{
    public class Writer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Book>? Books { get; set; }

    }
}
