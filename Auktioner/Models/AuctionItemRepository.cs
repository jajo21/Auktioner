﻿using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<AuctionItem> SoldAuctionItems()
        {
            return _appDbContext.AuctionItems.Where(a => a.InStock == false);
        }
        public IEnumerable<AuctionItem> AuctionItemsInStock(string username)
        {
            return _appDbContext.AuctionItems
                .Where(i => i.Purchaser == username)
                .Where(i => i.InStock == false);
        }

        public IEnumerable<AuctionItem> SoldAuctionItems(string username)
        {
            return _appDbContext.AuctionItems
                .Where(i => i.Purchaser == username)
                .Where(i => i.InStock == true);
        }

        public AuctionItem GetAuctionItemById(string id)
        {
            return _appDbContext.AuctionItems.FirstOrDefault(item => item.AuctionItemId == id);
        }        
        public void AddToInventory(AuctionItem item)
        {
            var AuctionItem = _appDbContext.AuctionItems.FirstOrDefault(i => i.AuctionItemId == item.AuctionItemId);
            if (item.Costs < item.StartingPrice && AuctionItem == null)
            {
                _appDbContext.AuctionItems.Add(item);
                _appDbContext.SaveChanges();
            }
        }
        public void Update(AuctionItem item)
        {
            var auctionItem = _appDbContext.AuctionItems.FirstOrDefault(a => a.AuctionItemId == item.AuctionItemId);
            if(auctionItem != null)
            {
                _appDbContext.AuctionItems.Update(item);
                _appDbContext.SaveChanges();
            }
        }
    }
}
