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
        public DbSet<Role> Roles{get;set;}
        public DbSet<CustomerRole> UserRoles { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){
            //Database.EnsureCreatedAsync();
        }
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            #region Game
            builder.Entity<Game>().ToTable("Games");
            builder.Entity<Game>().HasKey(x=>x.GameId);
            builder.Entity<Game>().Property(x=>x.GameId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Game>().Property(x=>x.Name).IsRequired();
            builder.Entity<Game>().Property(x=>x.Price).IsRequired();
            builder.Entity<Game>().Property(x=>x.GenreId).IsRequired();
            #endregion
            #region Genre
            builder.Entity<Genre>().ToTable("Genres");
            builder.Entity<Genre>().HasKey(x=>x.GenreId);
            builder.Entity<Genre>().Property(x=>x.GenreId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Genre>().Property(x=>x.Name).IsRequired();

            /*builder.Entity<Genre>().HasData(
                new Genre{GenreId = 1000,Name="Action"},
                new Genre{GenreId = 1001,Name="RPG"},
                new Genre{GenreId = 1002,Name="MMO"}
            );*/
            #endregion
            #region Role
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(x => x.RoleId);
            builder.Entity<Role>().Property(x => x.RoleId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(x => x.Name).IsRequired();
            builder.Entity<Role>().HasMany(x => x.UserRoles).WithOne(x => x.Role);
            #endregion
            #region CustomerRole
            builder.Entity<CustomerRole>().ToTable("CustomerRoles");
            builder.Entity<CustomerRole>().HasKey(x => new {x.RoleId, x.CustomerId});
            #endregion
            #region Customer
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(x => x.CustomerId);
            builder.Entity<Customer>().Property(x => x.CustomerId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(x => x.Name).IsRequired();
            builder.Entity<Customer>().Property(x => x.Surname).IsRequired();
            builder.Entity<Customer>().Property(x => x.Login).IsRequired();
            builder.Entity<Customer>().HasAlternateKey(x => x.Login);
            builder.Entity<Customer>().Property(x => x.Password).IsRequired();
            builder.Entity<Customer>().HasMany(x => x.UserRoles).WithOne(x => x.Customer);
            #endregion

        }  
    }
}