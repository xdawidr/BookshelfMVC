using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Domain.Interfaces
{
    public interface IWriterRepository
    {
        void DeleteWriter(int writerId);
        int AddWriter(Writer writer);
        void UpdateWriter(Writer writer);
        IQueryable<Writer> GetAllWriters();
        Writer GetWriterById(int id);
    }
}
