﻿using BookshelfMVC.Domain.Interfaces;
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

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null) 
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public int AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

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
            _context.Entry(book).Property("NumberOfPages").IsModified = true;
            _context.Entry(book).Property("YearOfPublish").IsModified = true;
            _context.Entry(book).Property("Price").IsModified = true;
            _context.Entry(book).Property("Language").IsModified = true;
            _context.SaveChanges();
        }
    }
}
