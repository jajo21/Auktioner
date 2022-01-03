using System.Collections.Generic;

namespace Auktioner.Models
{
    public interface IAuctionItemRepository
    {
        IEnumerable<AuctionItem> AllAuctionItems { get; }
        public IEnumerable<AuctionItem> AuctionItemsInStock();
        public void AddToInventory(AuctionItem item);
        public AuctionItem GetAuctionItemById(string id);
        public void Update(AuctionItem item);
    }
}
