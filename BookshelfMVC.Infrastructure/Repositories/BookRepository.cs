using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookshelfMVC.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null) 
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public async Task<int> AddBook(Book book)
        {
            _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public IQueryable<Book> GetBooksByStatusId(int statusId)
            =>  _context.Books.Where(x => x.BookStatusId == statusId);


        public Book GetBookById(int bookId)
            => _context.Books
            .Include(x => x.Writer)
            .Include(x => x.Publisher)
            .FirstOrDefault(x => x.Id == bookId);
           
        
            

        public IQueryable<Book> GetAllBooks()
         => _context.Books;

        public void UpdateBook(Book book)
        {
            _context.Attach(book);
            _context.Entry(book).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}
