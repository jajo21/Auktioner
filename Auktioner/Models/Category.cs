using Auktioner.CustomValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Var god ange ett namn på kategorin")]
        [Display(Name = "Kategori")]
        [StringLength(50, ErrorMessage = "Kategorin får inte vara längre än 50 tecken")]
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
