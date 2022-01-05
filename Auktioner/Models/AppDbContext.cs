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

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "ABC123456",
                Name = "Vinterlådan",
                Description = "Vinterlådan är en bra låda",
                Decade = 1990,
                StartingPrice = 1000,
                Costs = 700,
                Purchaser = "vinter@gg.se",
                CategoryName = "Vinter"

            });

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "DEF789123",
                Name = "Sommarlådan",
                Description = "Sommarlådan är en bra låda",
                Decade = 1980,
                StartingPrice = 1100,
                FinalPrice = 1300,
                Costs = 800,
                InStock = false,
                Purchaser = "sommar@gg.se",
                CategoryName = "Sommar"
            });

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "BEF789123",
                Name = "Höstlådan",
                Description = "Höstlådan är en bra låda",
                Decade = 1980,
                StartingPrice = 1100,
                Costs = 800,
                Purchaser = "höst@gg.se",
                CategoryName = "Höst"
            });

            modelBuilder.Entity<AuctionItem>().HasData(new AuctionItem
            {
                AuctionItemId = "CEF789123",
                Name = "Sommarlådan2",
                Description = "Sommarlådan är en bra låda2",
                Decade = 1980,
                StartingPrice = 1100,
                Costs = 800,
                Purchaser = "sommar@gg.se",
                CategoryName = "Sommar"
            });
        }
    }
}