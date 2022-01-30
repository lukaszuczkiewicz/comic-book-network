using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<ComicSeries> ComicSeries { get; set; }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<ComicComment> ComicComment { get; set; }

    }
}
