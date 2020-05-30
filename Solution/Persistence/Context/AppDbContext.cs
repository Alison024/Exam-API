using System;
using Microsoft.EntityFrameworkCore;
using Solution.Domain.Models;



namespace Solution.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Genre> Categories{get;set;}
        public DbSet<Genre> Genres{get;set;}
        public DbSet<Customer> Customers{get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
       
    }
}