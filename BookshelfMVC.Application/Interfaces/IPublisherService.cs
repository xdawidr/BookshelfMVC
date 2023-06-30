using BookshelfMVC.Application.ViewModels.Publishers;

namespace BookshelfMVC.Application.Interfaces
{
    public interface IPublisherService
    {
        ListPublisherForListVm GetAllPublishersForList(int pageSize, int pageNo, string searchString);
        Task<int> AddNewPublisher(NewPublisherVm publisherVm);
        PublisherDetailsVm GetPublisherDetails(int publisherId);
        NewPublisherVm GetPublisherForEdit(int id);
        void DeletePublisher(int id);
        void UpdatePublisher(NewPublisherVm model);
    }
}
