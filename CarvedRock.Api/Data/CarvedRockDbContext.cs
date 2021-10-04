using System;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Data
{
    public class CarvedRockDbContext: DbContext
    {
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options): base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductReview>().HasData(
                new ProductReview
                {
                    Id = 1,
                    Title = "Very Good",
                    Review = "It makes me feel like a real solider",
                    ProductId = 2
                },
                new ProductReview
                {
                    Id = 2,
                    Title = "Handy Dandy",
                    Review = "I climbed many mountains with this kit and it saved me many times. Definitely worth it.",
                    ProductId = 4
                },
                new ProductReview
                {
                    Id = 3,
                    Title = "Orange? more like yellow",
                    Review = "It's not orange enough, didn't like it",
                    ProductId = 6
                },new ProductReview
                {
                    Id = 4,
                    Title = "Very Speedy",
                    Review = "Drives very fast, recommend it to anyone",
                    ProductId = 5
                },
                new ProductReview
                {
                    Id = 5,
                    Title = "Very useful",
                    Review = "I can fill it up thousands of things and these still room for more. Amazing!",
                    ProductId = 3
                },
                new ProductReview
                {
                    Id = 6,
                    Title = "Terrible",
                    Review = "Leaves my feet cold and bruised. Soles fly right off.",
                    ProductId = 1
                });
            
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Mountain Walkers",
                    Description = "Use these sturdy shoes to pass any mountain range with ease.",
                    Price = 219.5m,
                    Rating = 4,
                    Type = ProductType.Boots,
                    Stock = 12,
                    PhotoFileName = "shutterstock_66842440.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 2,
                    Name = "Army Slippers",
                    Description = "For your everyday marches in the army.",
                    Price = 125.9m,
                    Rating = 3,
                    Type = ProductType.Boots,
                    Stock = 56,
                    PhotoFileName = "shutterstock_222721876.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                }, new Product
                {
                    Id = 3,
                    Name = "Backpack Deluxe",
                    Description = "This backpack can survive any tornado.",
                    Price = 199.99m,
                    Rating = 5,
                    Type = ProductType.ClimbingGear,
                    Stock = 66,
                    PhotoFileName = "shutterstock_6170527.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                }, new Product
                {
                    Id = 4,
                    Name = "Climbing Kit",
                    Description = "Anything you need to climb the mount Everest.",
                    Price = 299.5m,
                    Rating = 5,
                    Type = ProductType.ClimbingGear,
                    Stock = 3,
                    PhotoFileName = "shutterstock_48040747.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                }, new Product
                {
                    Id = 5,
                    Name = "Blue Racer",
                    Description = "Simply the fastest kayak on earth and beyond for 2 persons.",
                    Price = 350m,
                    Rating = 5,
                    Type = ProductType.Kayaks,
                    Stock = 8,
                    PhotoFileName = "shutterstock_441989509.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                }, new Product
                {
                    Id = 6,
                    Name = "Orange Demon",
                    Description = "One person kayak with hyper boost button.",
                    Price = 450m,
                    Rating = 2,
                    Type = ProductType.Kayaks,
                    Stock = 1,
                    PhotoFileName = "shutterstock_495259978.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
