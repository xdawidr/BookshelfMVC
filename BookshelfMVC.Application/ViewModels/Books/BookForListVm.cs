using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.ViewModels.Books
{
    public class BookForListVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WriterName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookForListVm>()
                .ForMember(s => s.WriterName, opt => opt.MapFrom(d=> d.Writer.Name));
        }
    }
}
