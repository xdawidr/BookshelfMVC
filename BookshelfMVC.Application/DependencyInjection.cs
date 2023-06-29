using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.Services;
using BookshelfMVC.Application.ViewModels.Books;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static BookshelfMVC.Application.ViewModels.Books.NewBookVm;

namespace BookshelfMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IValidator<NewBookVm>, NewBookValidator>();

            return services;
        } 
            
        
    }
}
