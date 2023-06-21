namespace BookshelfMVC.Domain.Model
{
    public class BookStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
