using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.ViewModels.Writers
{
    public class WriterForListVm : IMapFrom<Writer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Writer, WriterForListVm>()
                .ForMember(s => s.FullName, opt => opt.MapFrom(d => d.FirstName + " " + d.LastName));
                
        }
    }
}
