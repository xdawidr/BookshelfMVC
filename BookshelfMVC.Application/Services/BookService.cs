using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Books;
using BookshelfMVC.Domain.Interfaces;

namespace BookshelfMVC.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public int AddNewBook(NewBookVm book)
        {
            throw new NotImplementedException();
        }

        public ListBookForListVm GetAllBooksForList()
        {
            var books = _bookRepo.GetAllBooks()
                .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();

            var booksList = new ListBookForListVm()
            {
                Books = books,
                Count = books.Count
            };
            
            return booksList;
        }

        public BookDetailsVm GetBooksDetails(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
