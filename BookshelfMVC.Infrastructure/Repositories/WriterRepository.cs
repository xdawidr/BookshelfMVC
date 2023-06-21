using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookshelfMVC.Infrastructure.Repositories
{
    public class WriterRepository : IWriterRepository
    {
        private readonly BookDbContext _context;

        public WriterRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddWriter(Writer writer)
        {
            _context.Writers.Add(writer);
            return await _context.SaveChangesAsync();
        }

        public void DeleteWriter(int writerId)
        {
            var writer = _context.Writers.Find(writerId);
            if (writer != null) 
            {
                _context.Writers.Remove(writer);
                _context.SaveChanges();
            }
        }

        public IQueryable<Writer> GetAllWriters()
            => _context.Writers;
        

        public async Task<Writer> GetWriterById(int id)
            => await _context.Writers.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> UpdateWriter(Writer writer)
        {
            var writerToUpdate = _context.Writers.Find(writer);
            if (writerToUpdate != null)
            {
                _context.Update(writer);
                await _context.SaveChangesAsync();
            }

            return writer.Id;
        }
    }
}
