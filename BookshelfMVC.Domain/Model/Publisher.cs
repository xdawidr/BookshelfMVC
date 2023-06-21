namespace BookshelfMVC.Domain.Model
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<PublisherAddress> PublisherAddresses { get; set; }
        public ICollection<PublisherContactDetail> PublisherContactDetails { get; set; }

    }
}
