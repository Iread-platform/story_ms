using iread_story.DataAccess.Data.Entity;
using Microsoft.EntityFrameworkCore;

using System;

namespace iread_story.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        //entities
        public DbSet<Story> SysUsers { get; set; }

    }
}
