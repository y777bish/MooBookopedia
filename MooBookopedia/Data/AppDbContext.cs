using Microsoft.EntityFrameworkCore;
using MooBookopedia.Models;

namespace MooBookopedia.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books_Publisher>().HasKey(bp => new
            {
                bp.BooksId,
                bp.PublisherId
            });

            //To do; connections between models

            /*modelBuilder.Entity<Books_Publisher>().HasOne(p => p.BookPublisher).WithMany(bp => bp.Books_Publishers)*/

            modelBuilder.Entity<Movies_Producer>().HasKey(mp => new
            {
                mp.MoviesId,
                mp.ProducerId
            });

            //To generate different auth tables; we don't have to manually define the identifiers using it
            base.OnModelCreating(modelBuilder);
        }
    }
}
