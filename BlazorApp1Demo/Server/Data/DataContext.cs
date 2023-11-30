using BlazorApp1Demo.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1Demo.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comic>().HasData(
                    new Comic { Id = 1, Name = "Marvel" },
                    new Comic { Id = 2, Name = "DC" },
                    new Comic { Id = 3, Name = "Wanley" },
                    new Comic { Id = 4, Name = "Mirage Studio" }
            );
            modelBuilder.Entity<SuperHero>().HasData(
                     new SuperHero
                     {
                         Id = 1,
                         FirstName = "Peter",
                         LastName = "Parker",
                         HeroName = "Miranha",
                         ComicId = 1
                     },
                    new SuperHero
                    {
                        Id = 2,
                        FirstName = "Bruce",
                        LastName = "Wayne",
                        HeroName = "Batman",
                        ComicId = 2
                    },
                    new SuperHero
                    {
                        Id = 3,
                        FirstName = "Tony",
                        LastName = "Stark",
                        HeroName = "Iron Man",
                        ComicId = 1
                    },
                    new SuperHero
                    {
                        Id = 4,
                        FirstName = "Tin",
                        LastName = "Hin",
                        HeroName = "Tin tin",
                        ComicId = 4
                    }

               );
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Comic> Comics { get; set; }

    }
}
