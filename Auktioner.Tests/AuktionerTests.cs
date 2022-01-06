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
        public void GetArticlesInStock()    // Kontrollerar att det g�r att h�mta r�tt antal objekt via metoderna och kontrollera att det st�mmer
        {                                   // �verens genom att se hur m�nga objekt som finns kvar i lager.
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
                StartingPrice = 1000,   //Utg�ngspris l�gre �n kostnad
                Costs = 1100,   //Kostnad h�gre �n utg�ngspris
                Purchaser = "test@test.se",
                CategoryName = "Vinter"
            };
            _auctionItemRepository.AddToInventory(testItem);

            int expected = itemsInInventoryBeforeAdd; //B�r vara samma eftersom inget har lagts till p� grund av felaktigheter
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
        public void NotBeAbleToAddToInventoryWithSameIdToDatabase()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("test").Options;
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
            _auctionItemRepository.AddToInventory(testItem); // Bör ej fungera eftersom detta ID redan existerar i databasen.

            int actual = _appDbContext.AuctionItems.Count();
            int expected = itemsInInventoryBeforeAdd; //B�r vara samma eftersom inget har lagts till

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void UpdateItem() // Kollar om det går att redigera och updatera ett objekt i databasen genom matoden update
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("test").Options;
            using var _appDbContext = new AppDbContext(options);
            AuctionItemRepository _auctionItemRepository = new(_appDbContext);

            var testItem = _auctionItemRepository.GetAuctionItemById("ABC123456");
            testItem.Name = "Sommar";
            _auctionItemRepository.Update(testItem);

            string actual = _auctionItemRepository.GetAuctionItemById("ABC123456").Name;
            string expected = "Sommar";

            Assert.Equal(expected, actual);
        }
    }
}
