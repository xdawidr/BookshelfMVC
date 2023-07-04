using AutoMapper;
using BookshelfMVC.Application.Mapping;
using BookshelfMVC.Domain.Model;
using FluentValidation;

namespace BookshelfMVC.Application.ViewModels.Writers
{
    public class NewWriterVm : IMapFrom<Writer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewWriterVm, Writer>().ReverseMap();
        }

        public class NewWriterValidator : AbstractValidator<NewWriterVm>
        {
            public NewWriterValidator()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Name).NotEmpty();
            }
        }
    }
}
