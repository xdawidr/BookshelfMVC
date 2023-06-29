using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;
using FluentValidation;

namespace BookshelfMVC.Application.ViewModels.Books
{
    public class NewBookVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewBookVm, Book>().ReverseMap();
        }

        public class NewBookValidator : AbstractValidator<NewBookVm>
        {
            public NewBookValidator()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Name).NotEmpty();
            }
        }
    }
}
