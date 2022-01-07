using System.Collections.Generic;
using Auktioner.Models;

namespace Auktioner.ViewModels
{
    public class InventoryListViewModel
    {
        public IEnumerable<AuctionItem> AuctionItems {get; set;}
        public AppUser ThisUser { get; set;}
    }
}
