
using BookshelfMVC.Application.ViewModels.Books;

namespace BookshelfMVC.Application.Interfaces
{
    public interface IBookService
    {
        ListBookForListVm GetAllBooksForList(int pageSize, int pageNo, string searchString);
        Task<int> AddNewBook(NewBookVm bookVm);
        BookDetailsVm GetBookDetails(int bookId);
        NewBookVm GetBookForEdit(int id);
        void DeleteBook(int id);
        void UpdateBook(NewBookVm model);
    }
}
