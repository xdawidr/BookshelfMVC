using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.ViewModels.Publishers
{
    public class PublisherForListVm : IMapFrom<Publisher>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Publisher, PublisherForListVm>();
        }
    }
}
