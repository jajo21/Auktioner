using System.Collections.Generic;

namespace Auktioner.Models
{
    public class Category
    {
        int categoryId;
        string categoryName;
        List<AuctionItem> auctionItems;
        public int CategoryId
        {
            get { return this.categoryId; }
            set { this.categoryId = value; }
        }
        public string CategoryName
        {
            get { return this.categoryName; }
            set { this.categoryName = value; }
        }
        public List<AuctionItem> AuctionItems
        {
            get { return this.auctionItems; }
            set { this.auctionItems = value;}
        }
    }
}
