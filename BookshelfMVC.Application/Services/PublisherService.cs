using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Publishers;
using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepo;
        private readonly IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepo, IMapper mapper)
        {
            _publisherRepo = publisherRepo;
            _mapper = mapper;
        }

        public int AddNewPublisher(NewPublisherVm publisherVm)
        {
            var publisher = _mapper.Map<Publisher>(publisherVm);
            var id =  _publisherRepo.AddPublisher(publisher);
            return id;

        }

        public void DeletePublisher(int id)
        {
            _publisherRepo.DeletePublisher(id);
        }

        public ListPublisherForListVm GetAllPublishersForList(int pageSize, int pageNo, string searchString)
        {
            var publishers = _publisherRepo.GetAllPublishers().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<PublisherForListVm>(_mapper.ConfigurationProvider).ToList();
            var publishersToShow = publishers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var publishersList = new ListPublisherForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Publishers = publishers,
                Count = publishers.Count

            };

            return publishersList;
        }

        public PublisherDetailsVm GetPublisherDetails(int publisherId)
        {
            var publisher = _publisherRepo.GetPublisherById(publisherId);
            var publisherVm = _mapper.Map<PublisherDetailsVm>(publisher);

            return publisherVm;
        }

        public NewPublisherVm GetPublisherForEdit(int id)
        {
            var publisher = _publisherRepo.GetPublisherById(id);
            var publisherVm = _mapper.Map<NewPublisherVm>(publisher);
            return publisherVm;
        }

        public void UpdatePublisher(NewPublisherVm model)
        {
            var publisher = _mapper.Map<Publisher>(model);
            _publisherRepo.UpdatePublisher(publisher);
        }
    }
}
