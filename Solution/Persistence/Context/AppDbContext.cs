using System;
using Microsoft.EntityFrameworkCore;
using Solution.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;


namespace Solution.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Game> Games{get;set;}
        public DbSet<Genre> Genres{get;set;}
        public DbSet<Customer> Customers{get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.Entity<Game>().ToTable("Games");
            builder.Entity<Game>().HasKey(x=>x.GameId);
            builder.Entity<Game>().Property(x=>x.GameId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Game>().Property(x=>x.Name).IsRequired();
            builder.Entity<Game>().Property(x=>x.Price).IsRequired();
            builder.Entity<Game>().Property(x=>x.GenreId).IsRequired();

            builder.Entity<Genre>().ToTable("Genres");
            builder.Entity<Genre>().HasKey(x=>x.GenreId);
            builder.Entity<Genre>().Property(x=>x.GenreId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Genre>().Property(x=>x.Name).IsRequired();
            builder.Entity<Genre>().HasData(
                new Genre{GenreId = 1,Name="Action"},
                new Genre{GenreId = 2,Name="RPG"},
                new Genre{GenreId = 3,Name="MMO"}
            );
        }  
    }
}