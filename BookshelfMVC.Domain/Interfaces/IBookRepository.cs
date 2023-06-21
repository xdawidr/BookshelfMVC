using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Domain.Interfaces
{
    public interface IBookRepository
    {
        void DeleteBook(int bookId);
        Task<int> AddBook(Book book);
        Task<int> UpdateBook(Book book);
        IQueryable<Book> GetBooksByStatusId(int statusId);
        Task<Book> GetBookById(int id);
    }
}
