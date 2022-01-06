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

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Dekoration" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Transport" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Hushåll" });

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "ABC123456",
                Name = "Bänk",
                Description = "En underbar bänk från tidigt 90-tal",
                Decade = 1990,
                StartingPrice = 7000,
                Costs = 6000,
                Purchaser = "göran@gg.se",
                CategoryName = "Dekoration"

            });

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "DEF789123",
                Name = "Supersnabben",
                Description = "En kanonbil för den motorkunnige!",
                Decade = 1980,
                StartingPrice = 20000,
                FinalPrice = 25000,
                Costs = 14000,
                InStock = false,
                Purchaser = "gösta@gg.se",
                CategoryName = "Transport"
            });

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "BEF789123",
                Name = "Servis",
                Description = "En kanonfin servis!",
                Decade = 1980,
                StartingPrice = 3000,
                Costs = 1500,
                Purchaser = "bengt@gg.se",
                CategoryName = "Hushåll"
            });

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "CEF789123",
                Name = "Klocka",
                Description = "Finfin klocka.",
                Decade = 1980,
                StartingPrice = 2000,
                Costs = 800,
                Purchaser = "bengt@gg.se",
                CategoryName = "Dekoration"
            });
        }
    }
}