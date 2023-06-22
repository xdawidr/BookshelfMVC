using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.ViewModels.Books
{
    public class BookDetailsVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public int YearOfPublish { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsVm>();
        }
    }
}
