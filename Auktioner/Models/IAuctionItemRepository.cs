using System.Collections.Generic;

namespace Auktioner.Models
{
    public interface IAuctionItemRepository
    {
        IEnumerable<AuctionItem> AllAuctionItems { get; }
        IEnumerable<AuctionItem> AuctionItemsInStock();
        IEnumerable<AuctionItem> AuctionItemsInStock(string username);
        IEnumerable<AuctionItem> SoldAuctionItems();
        IEnumerable<AuctionItem> SoldAuctionItems(string username);
        void AddToInventory(AuctionItem item);
        AuctionItem GetAuctionItemById(string id);
        void Update(AuctionItem item);
    }
}
