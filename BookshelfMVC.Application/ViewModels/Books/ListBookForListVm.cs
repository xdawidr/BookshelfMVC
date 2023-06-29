namespace BookshelfMVC.Application.ViewModels.Books
{
    public class ListBookForListVm
    {
        public List<BookForListVm> Books { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SearchString { get; set; }
    }
}
