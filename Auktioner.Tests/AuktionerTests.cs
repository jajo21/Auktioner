using Auktioner.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Auktioner.Tests
{
    public class AuktionerTests
    {
        [Fact]
        public void GetArticlesInStock()    // Kontrollerar att det går att hämta rätt antal objekt via metoderna och kontrollera att det stämmer
        {                                   // överens genom att se hur många objekt som finns kvar i lager.
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("test").Options;
            using var _appDbContext = new AppDbContext(options);
            AuctionItemRepository _auctionItemRepository = new(_appDbContext);

            var itemsInStock = _auctionItemRepository.AuctionItemsInStock().Count();
            var totalItems = _auctionItemRepository.AllAuctionItems.Count();
            var itemsSold = _auctionItemRepository.SoldAuctionItems().Count();

            int expected = itemsInStock;
            int actual = totalItems - itemsSold;
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ItemsWithCostsHigherThanStartPriceShouldNotBeAbleToBeAdded () 
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("test").Options;
            using var _appDbContext = new AppDbContext(options);
            AuctionItemRepository _auctionItemRepository = new(_appDbContext);

            var itemsInInventoryBeforeAdd = _appDbContext.AuctionItems.Count();
            var testItem = new AuctionItem
            {
                AuctionItemId = "ABC134561",
                Name = "Artikel test",
                Description = "Artikel beskrivning",
                Decade = 1990,
                StartingPrice = 1000,   //Utgångspris lägre än kostnad
                Costs = 1100,   //Kostnad högre än utgångspris
                Purchaser = "test@test.se",
                CategoryName = "Vinter"
            };
            _auctionItemRepository.AddToInventory(testItem);

            int expected = itemsInInventoryBeforeAdd; //Bör vara samma eftersom inget har lagts till på grund av felaktigheter
            int actual = _appDbContext.AuctionItems.Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddItemToInventory()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("test").Options;
            using var _appDbContext = new AppDbContext(options);
            AuctionItemRepository _auctionItemRepository = new(_appDbContext);

            var itemsInInventoryBeforeAdd = _appDbContext.AuctionItems.Count();
            var testItem = new AuctionItem
            {
                AuctionItemId = "ABC134561",
                Name = "Artikel test",
                Description = "Artikel beskrivning",
                Decade = 1990,
                StartingPrice = 1000,
                Costs = 700,
                Purchaser = "test@test.se",
                CategoryName = "Vinter"
            };
            _auctionItemRepository.AddToInventory(testItem);

            int expected = itemsInInventoryBeforeAdd + 1;
            int actual = _appDbContext.AuctionItems.Count();
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NotBeAbleToAddInventoryWithSameIdToDatabase()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("test").Options;

            using var _appDbContext = new AppDbContext(options);
            AuctionItemRepository _auctionItemRepository = new(_appDbContext);
            var itemsInInventoryBeforeAdd = _appDbContext.AuctionItems.Count();
            var testItem = new AuctionItem
            {
                AuctionItemId = "ABC123456", //Jag vet att detta id redan existerar i databasen
                Name = "Artikel test",
                Description = "Artikel beskrivning",
                Decade = 1990,
                StartingPrice = 1000,
                Costs = 700,
                Purchaser = "test@test.se",
                CategoryName = "Vinter"
            };
            _auctionItemRepository.AddToInventory(testItem);

            int actual = _appDbContext.AuctionItems.Count();
            int expected = itemsInInventoryBeforeAdd; //Bör vara samma eftersom inget har lagts till

            Assert.Equal(expected, actual);
        }

    }
}
