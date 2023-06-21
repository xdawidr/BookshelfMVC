using BookshelfMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookshelfMVC.Domain.Interfaces
{
    public interface IWriterRepository
    {
        void DeleteWriter(int writerId);
        Task<int> AddWriter(Writer writer);
        Task<int> UpdateWriter(Writer writer);
        IQueryable<Writer> GetAllWriters();
        Task<Writer> GetWriterById(int id);
    }
}
