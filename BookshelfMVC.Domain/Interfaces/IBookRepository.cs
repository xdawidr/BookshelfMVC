using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Domain.Interfaces
{
    public interface IBookRepository
    {
        void DeleteBook(int id);
        int AddBook(Book book);
        IQueryable<Book> GetBooksByStatusId(int statusId);
        IQueryable<Book> GetAllBooks();
        Book GetBookById(int bookId);
        void UpdateBook(Book book);
    }
}
