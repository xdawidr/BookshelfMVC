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
                _context.SaveChangesAsync();
            }
        }

        public async Task<int> AddBook(Book book)
        {
            _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<int> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public IQueryable<Book> GetBooksByStatusId(int statusId)
            =>  _context.Books.Where(x => x.BookStatusId == statusId);
       

        public async Task<Book> GetBookById(int id)
            =>  await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
      
        
    }
}
