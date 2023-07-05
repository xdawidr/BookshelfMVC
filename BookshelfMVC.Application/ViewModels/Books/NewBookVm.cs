using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Application.ViewModels.Publishers;
using BookshelfMVC.Application.ViewModels.Writers;
using BookshelfMVC.Domain.Model;
using FluentValidation;

namespace BookshelfMVC.Application.ViewModels.Books
{
    public class NewBookVm : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? NumberOfPages { get; set; }
        public int? YearOfPublish { get; set; }
        public decimal? Price { get; set; }
        public string? Language { get; set; }

        public int WriterId { get; set; }
        public List<WriterForListVm> Writers { get; set; }
        public int PublisherId { get; set; }
        public List<PublisherForListVm> Publishers { get; set; }

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
                RuleFor(b => b.PublisherId).NotNull();
                RuleFor(b => b.WriterId).NotNull();
            }
        }
    }
}
