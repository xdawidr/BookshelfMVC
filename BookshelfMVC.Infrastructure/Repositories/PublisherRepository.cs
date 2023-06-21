using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

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
        public async Task<int> UpdatePublisher(Publisher publisher)
        {
            var publisherToUpdate = _context.Writers.Find(publisher);
            if (publisherToUpdate != null)
            {
                _context.Update(publisher);
                await _context.SaveChangesAsync();
            }

            return publisher.Id;
        }
        public IQueryable<Publisher> GetAllPublishers()
            => _context.Publishers;

        public async Task<Publisher> GetPublisherById(int id)
            => await _context.Publishers.FirstOrDefaultAsync(x => x.Id == id);

    }
}
