using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.ViewModels.Writers
{
    public class WriterDetailsVm : IMapFrom<Writer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Writer, WriterDetailsVm>();
        }
    }
}
