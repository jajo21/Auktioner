using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auktioner.Models
{
    public class AuctionItemRepository : IAuctionItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public AuctionItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<AuctionItem> AllAuctionItems
        {
            get
            {
                return _appDbContext.AuctionItems;
            }
        }
        public IEnumerable<AuctionItem> AuctionItemsInStock()
        {
            return _appDbContext.AuctionItems.Where(a => a.InStock == true);
        }
        public void AddToInventory(AuctionItem item)
        {
            if(item.Costs < item.StartingPrice)// Domänlogik behövs för att inte kunna lägga till en artikel där kostnad är högra än utgångspris ????
            {
                _appDbContext.AuctionItems.Add(item);
                _appDbContext.SaveChanges();
            }
        }
        public AuctionItem GetAuctionItemByID(string id)
        {
            return _appDbContext.AuctionItems.FirstOrDefault(item => item.AuctionItemId == id);
        }
        public void Update(AuctionItem item)
        {
            _appDbContext.AuctionItems.Update(item);
            _appDbContext.SaveChanges();
        }
        //public void RemoveFromInventory(AuctionItem article)
        //{
        //    _appDbContext.AuctionItems.Remove(article);
        //    _appDbContext.SaveChanges();
        //}
    }
}
