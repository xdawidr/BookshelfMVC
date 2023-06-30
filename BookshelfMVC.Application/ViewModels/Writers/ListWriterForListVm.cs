namespace BookshelfMVC.Application.ViewModels.Writers
{
    public class ListWriterForListVm
    {
        public List<WriterForListVm> Writers { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SearchString { get; set; }
    }
}
