using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.ViewModels.Books
{
    public class BookDetailsVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WriterName { get; set; }
        public int NumberOfPages { get; set; }
        public int YearOfPublish { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsVm>()
                .ForMember(s => s.WriterName, opt => opt.MapFrom(d => d.Writer.Name))
                .ForMember(s => s.Publisher, opt => opt.MapFrom(d => d.Publisher.Name));
        }
    }
}
