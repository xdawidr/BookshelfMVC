using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.Services;
using BookshelfMVC.Application.ViewModels.Books;
using BookshelfMVC.Application.ViewModels.Publishers;
using BookshelfMVC.Application.ViewModels.Writers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static BookshelfMVC.Application.ViewModels.Books.NewBookVm;
using static BookshelfMVC.Application.ViewModels.Publishers.NewPublisherVm;
using static BookshelfMVC.Application.ViewModels.Writers.NewWriterVm;

namespace BookshelfMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<IWriterService, WriterService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IValidator<NewBookVm>, NewBookValidator>();
            services.AddTransient<IValidator<NewPublisherVm>, NewPublisherValidator>();
            services.AddTransient<IValidator<NewWriterVm>, NewWriterValidator>();

            return services;
        } 
            
        
    }
}
