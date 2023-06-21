using BookshelfMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookshelfMVC.Infrastructure
{
    public class BookDbContext : DbContext
    {
        
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<PublisherAddress> PublisherAddresses { get; set; }
        public DbSet<PublisherContactDetail> PublisherContactDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
           
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
