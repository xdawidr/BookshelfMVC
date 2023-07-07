using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;
using FluentValidation;

namespace BookshelfMVC.Application.ViewModels.Publishers
{
    public class NewPublisherVm : IMapFrom<Publisher>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? NIP { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPublisherVm, Publisher>().ReverseMap();
        }

        public class NewPublisherValidator : AbstractValidator<NewPublisherVm>
        {
            public NewPublisherValidator()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.NIP).Length(10);
            }
        }
    }
}
