using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;

namespace BookshelfMVC.Application.ViewModels.Books
{
    public class BookForListVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookForListVm>();
        }
    }
}
