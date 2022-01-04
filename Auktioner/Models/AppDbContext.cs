using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auktioner.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        DbSet<AuctionItem> articles;
        DbSet<Category> categories;
        
        public DbSet<AuctionItem> AuctionItems
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
        public DbSet<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Vinter" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Sommar" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Höst" });

            //modelBuilder.Entity<AppUser>().HasData(new AppUser { AppUserId = 1, Email = "gretagranit@gg.se", });

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "ABC123456",
                Name = "Artikel test",
                Description = "Artikel beskrivning",
                Decade = 1990,
                StartingPrice = 1000,
                Costs = 700,
                CategoryName = "Vinter"

            });

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "DEF789123",
                Name = "Artikel test2",
                Description = "Artikel beskrivning2",
                Decade = 1980,
                StartingPrice = 1100,
                FinalPrice = 1300,
                Costs = 800,
                InStock = false,
                CategoryName = "Sommar"
            });
        }
    }
}