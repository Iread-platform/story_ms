using iread_story.DataAccess.Data.Entity;
using Microsoft.EntityFrameworkCore;

using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace iread_story.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>().HasOne(s => s.Language).WithMany(l => l.Stories).OnDelete(DeleteBehavior.Cascade);
        }


        //entities
        public DbSet<Story> Stories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Language> Languages { get; set; }

    }
}
