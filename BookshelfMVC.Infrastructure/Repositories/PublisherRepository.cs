using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookDbContext _context;

        public PublisherRepository(BookDbContext context)
        {
            _context = context;
        }

        public void DeletePublisher(int publisherId)
        {
            var publisher = _context.Publishers.Find(publisherId);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }

        public async Task<int> AddPublisher(Publisher publisher)
        {
            _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();

            return publisher.Id;
        }
        public void UpdatePublisher(Publisher publisher)
        {
            _context.Attach(publisher);
            _context.Entry(publisher).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
        public IQueryable<Publisher> GetAllPublishers()
            => _context.Publishers;

        public Publisher GetPublisherById(int id)
            =>  _context.Publishers.FirstOrDefault(x => x.Id == id);

    }
}
