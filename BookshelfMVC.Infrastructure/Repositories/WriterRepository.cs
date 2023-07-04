using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Infrastructure.Repositories
{
    public class WriterRepository : IWriterRepository
    {
        private readonly BookDbContext _context;

        public WriterRepository(BookDbContext context)
        {
            _context = context;
        }

        public int AddWriter(Writer writer)
        {
            _context.Writers.Add(writer);
            return _context.SaveChanges();
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
        
        public Writer GetWriterById(int id)
            => _context.Writers.FirstOrDefault(x => x.Id == id);

        public void UpdateWriter(Writer writer)
        {
            _context.Attach(writer);
            _context.Entry(writer).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}
