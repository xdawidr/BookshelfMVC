using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Writers;
using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.Services
{
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepo;
        private readonly IMapper _mapper;

        public WriterService(IWriterRepository writerRepo, IMapper mapper)
        {
            _writerRepo = writerRepo;
            _mapper = mapper;
        }

        public async Task<int> AddNewWriter(NewWriterVm writerVm)
        {
            var writer = _mapper.Map<Writer>(writerVm);
            var id = await _writerRepo.AddWriter(writer);
            return id;
        }

        public void DeleteWriter(int id)
        {
            _writerRepo.DeleteWriter(id);
        }

        public ListWriterForListVm GetAllWritersForList(int pageSize, int pageNo, string searchString)
        {
            var writers = _writerRepo.GetAllWriters().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<WriterForListVm>(_mapper.ConfigurationProvider).ToList();
            var writersToShow = writers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var writersList = new ListWriterForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Writers = writers,
                Count = writers.Count

            };

            return writersList;
        }

        public WriterDetailsVm GetWriterDetails(int writerId)
        {
           var writer =  _writerRepo.GetWriterById(writerId);
           var writerVm = _mapper.Map<WriterDetailsVm>(writer);
           return writerVm;
        }

        public NewWriterVm GetWriterForEdit(int id)
        {
            var writer = _writerRepo.GetWriterById(id);
            var writerVm = _mapper.Map<NewWriterVm>(writer);
            
            return writerVm;
            
        }

        public void UpdateWriter(NewWriterVm model)
        {
            var writer = _mapper.Map<Writer>(model);
            _writerRepo.UpdateWriter(writer);
        }
    }
}
