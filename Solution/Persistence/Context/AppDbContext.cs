using System.Security.AccessControl;
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
            builder.Entity<Game>().HasData(
                new Game{GameId = 1, Name = "Call of Duty", Price = 30, GenreId=1, Description = null},
                new Game{GameId = 2, Name = "StarCraft II: Wings of Liberty", Price = 20, GenreId=2, Description = null},
                new Game{GameId = 3, Name = "Metal gear rising: revengeance", Price = 15, GenreId=3, Description = null},
                new Game{GameId = 4, Name = "Dead Cells", Price = 30, GenreId=4, Description = null},
                new Game{GameId = 5, Name = "The Elder Scrolls V: Skyrim", Price = 45, GenreId=5, Description = null}
            );
            #endregion
            #region Genre
            builder.Entity<Genre>().ToTable("Genres");
            builder.Entity<Genre>().HasKey(x=>x.GenreId);
            builder.Entity<Genre>().Property(x=>x.GenreId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Genre>().Property(x=>x.Name).IsRequired();
            builder.Entity<Genre>().HasData(
                new Genre{GenreId = 1,Name="Action"},
                new Genre{GenreId = 2,Name="Strategy"},
                new Genre{GenreId = 3,Name="Hack and Slash"},
                new Genre{GenreId = 4,Name="Roguelike"},
                new Genre{GenreId = 5,Name="RPG"}
            );
            #endregion
            #region Role
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(x => x.RoleId);
            builder.Entity<Role>().Property(x => x.RoleId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(x => x.Name).IsRequired();
            builder.Entity<Role>().HasMany(x => x.UserRoles).WithOne(x => x.Role);
            builder.Entity<Role>().HasData(
                new Role {RoleId = 1, Name="admin"},
                new Role {RoleId = 2, Name="customer"},
                new Role {RoleId = 3, Name="manager"}
            );
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
            builder.Entity<Customer>().HasData(
                new Customer{
                    CustomerId = 1,
                    Name = "Andrey",
                    Surname = "Ublinskykh",
                    Login="Andreo2000",
                    Password="123123"
                },
                new Customer{
                    CustomerId = 2,
                    Name = "Vlad",
                    Surname = "Vovk",
                    Login="int123",
                    Password="123456"
                },
                new Customer{
                    CustomerId = 3,
                    Name = "Nikita",
                    Surname = "Popov",
                    Login="LoveGame1",
                    Password="000000"
                }
            );
            #endregion
            #region CustomerRole
            builder.Entity<CustomerRole>().ToTable("CustomerRoles");
            builder.Entity<CustomerRole>().HasKey(x => new {x.CustomerId, x.RoleId});
            builder.Entity<CustomerRole>().HasData(
                new CustomerRole{CustomerId = 1, RoleId = 1},
                new CustomerRole{CustomerId = 1, RoleId = 2},
                new CustomerRole{CustomerId = 2, RoleId = 1},
                new CustomerRole{CustomerId = 2, RoleId = 2},
                new CustomerRole{CustomerId = 2, RoleId = 3},
                new CustomerRole{CustomerId = 3, RoleId = 1}
            );
            #endregion
        }  
    }
}