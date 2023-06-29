using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookshelfMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();

            return services;
        }
    }
}
