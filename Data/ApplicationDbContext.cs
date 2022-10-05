using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using tezt.Models;

namespace tezt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<AuctionItem> AuctionItems { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Transport" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Decoration" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "HouseHold" });


           
        }

    }
}
