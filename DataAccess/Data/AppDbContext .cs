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
            int index = 0;
            modelBuilder.Entity<Language>().HasData(CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().ConvertAll<Language>((CultureInfo c) =>
            {
                index += 1;
                return new Language() { Name = c.EnglishName, Code = c.TwoLetterISOLanguageName, LanguageId = index };
            }));
        }


        //entities
        public DbSet<Story> Stories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Language> Languages { get; set; }

    }
}
