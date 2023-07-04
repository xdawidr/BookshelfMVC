namespace BookshelfMVC.Domain.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? NumberOfPages { get; set; }
        public int? YearOfPublish { get; set; }
        public decimal? Price { get; set; }
        public string? Language { get; set; }

        public Writer? Writer { get; set; }
        public int? WriterId { get; set; }
        public BookStatus? BookStatus { get; set; }
        public int? BookStatusId { get; set; }
        public Genre? Genre { get; set; }
        public int? GenreId { get; set; }
        public Publisher? Publisher { get; set; }
        public int? PublisherId { get; set; }

    }
}
