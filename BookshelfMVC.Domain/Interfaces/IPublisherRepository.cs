using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Domain.Interfaces
{
    public interface IPublisherRepository
    {
        void DeletePublisher(int publisherId);
        Task<int> AddPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        IQueryable<Publisher> GetAllPublishers();
        Publisher GetPublisherById(int id);
    }
}
