using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Books;
using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public async Task<int> AddNewBook(NewBookVm bookVm)
        {
            var book = _mapper.Map<Book>(bookVm);
            var id = await _bookRepo.AddBook(book);
            return id;
        }

        public void DeleteBook(int id)
        {
            _bookRepo.DeleteBook(id);
        }

        public ListBookForListVm GetAllBooksForList(int pageSize, int pageNo, string searchString)
        {
            var books = _bookRepo.GetAllBooks().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();
            var booksToShow = books.Skip(pageSize*(pageNo - 1)).Take(pageSize).ToList();
            var booksList = new ListBookForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Books = books,
                Count = books.Count

            };
            
            return booksList;
        }

        public BookDetailsVm GetBookDetails(int bookId)
        {
            var book = _bookRepo.GetBookById(bookId);

            var bookVm = _mapper.Map<BookDetailsVm>(book);

            return bookVm;
            
        }

        public NewBookVm GetBookForEdit(int id)
        {
            var book = _bookRepo.GetBookById(id);
            var bookVm = _mapper.Map<NewBookVm>(book);
            return bookVm;
        }

        public void UpdateBook(NewBookVm model)
        {
            var book = _mapper.Map<Book>(model);
            _bookRepo.UpdateBook(book);
        }
    }
}
