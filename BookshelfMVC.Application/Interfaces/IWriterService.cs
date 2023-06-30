using BookshelfMVC.Application.ViewModels.Books;
using BookshelfMVC.Application.ViewModels.Writers;

namespace BookshelfMVC.Application.Interfaces
{
    public interface IWriterService
    {
        ListWriterForListVm GetAllWritersForList(int pageSize, int pageNo, string searchString);
        Task<int> AddNewWriter(NewWriterVm writerVm);
        WriterDetailsVm GetWriterDetails(int writerId);
        NewWriterVm GetWriterForEdit(int id);
        void DeleteWriter(int id);
        void UpdateWriter(NewWriterVm model);
    }
}
