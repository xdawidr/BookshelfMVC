using BookshelfMVC.Application.ViewModels.Books;
using BookshelfMVC.Application.ViewModels.Publishers;
using BookshelfMVC.Application.ViewModels.Writers;

namespace BookshelfMVC.Application.Interfaces
{
    public interface IBookService
    {
        ListBookForListVm GetAllBooksForList(int pageSize, int pageNo, string searchString);
        int AddNewBook(NewBookVm bookVm);
        BookDetailsVm GetBookDetails(int bookId);
        NewBookVm GetBookForEdit(int id);
        void DeleteBook(int id);
        void UpdateBook(NewBookVm model);
        IQueryable<PublisherForListVm> GetPublishers();
        IQueryable<WriterForListVm> GetWriters();
        NewBookVm SetParametersToVm(NewBookVm model);
    }
}
