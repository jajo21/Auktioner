using System.Collections.Generic;

namespace Auktioner.Models
{
    public interface IAuctionItemRepository
    {
        IEnumerable<AuctionItem> AllAuctionItems { get; }
        public IEnumerable<AuctionItem> AuctionItemsInStock();
        public void AddToInventory(AuctionItem auctionItem);
        public AuctionItem GetAuctionItemByID(string id);
        public void Update(AuctionItem article);
    }
}
