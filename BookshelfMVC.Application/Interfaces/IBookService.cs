
using BookshelfMVC.Application.ViewModels.Books;

namespace BookshelfMVC.Application.Interfaces
{
    public interface IBookService
    {
        ListBookForListVm GetAllBooksForList();
        int AddNewBook(NewBookVm book);
        BookDetailsVm GetBooksDetails(int bookId);
    }
}
