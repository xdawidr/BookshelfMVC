using BookshelfMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookshelfMVC.Domain.Interfaces
{
    public interface IPublisherRepository
    {
        void DeletePublisher(int publisherId);
        Task<int> AddPublisher(Publisher publisher);
        Task<int> UpdatePublisher(Publisher publisher);
        IQueryable<Publisher> GetAllPublishers();
        Task<Publisher> GetPublisherById(int id);
    }
}
