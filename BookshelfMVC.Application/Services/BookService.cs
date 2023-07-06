using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Books;
using BookshelfMVC.Application.ViewModels.Publishers;
using BookshelfMVC.Application.ViewModels.Writers;
using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepo, IPublisherRepository publisherRepository, IWriterRepository writerRepository, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _publisherRepository = publisherRepository;
            _writerRepository = writerRepository;
            _mapper = mapper;
        }

        public int AddNewBook(NewBookVm bookVm)
        {
            var book = _mapper.Map<Book>(bookVm);
            var id =  _bookRepo.AddBook(book);
            return id;
        }

        public NewBookVm SetParametersToVm(NewBookVm model)
        {
            model.Publishers = GetPublishers().ToList();
            model.Writers = GetWriters().ToList();
            return model;
        }

        public IQueryable<PublisherForListVm> GetPublishers()
        {
            var publishers = _publisherRepository.GetAllPublishers()
                .ProjectTo<PublisherForListVm>(_mapper.ConfigurationProvider);
            return publishers;
        }

        public IQueryable<WriterForListVm> GetWriters()
        {
            var writers = _writerRepository.GetAllWriters()
                .ProjectTo<WriterForListVm>(_mapper.ConfigurationProvider);
            return writers;
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
