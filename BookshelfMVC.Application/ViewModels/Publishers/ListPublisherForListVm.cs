namespace BookshelfMVC.Application.ViewModels.Publishers
{
    public class ListPublisherForListVm
    {
        public List<PublisherForListVm> Publishers { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SearchString { get; set; }
    }
}
