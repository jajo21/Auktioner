using System.Collections.Generic;
using Auktioner.Models;

namespace Auktioner.ViewModels
{
    public class InventoryListViewModel
    {
        IEnumerable<AuctionItem> auctionItems;
        public IEnumerable<AuctionItem> AuctionItems
        {
            get { return this.auctionItems; }
            set { this.auctionItems = value; }
        }
    }
}
