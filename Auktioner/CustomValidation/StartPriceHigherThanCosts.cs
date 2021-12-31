using Auktioner.Models;
using System.ComponentModel.DataAnnotations;

namespace Auktioner.CustomValidation
{
    public class StartPriceHigherThanCosts : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var auctionItem = (AuctionItem)validationContext.ObjectInstance;

            return (auctionItem.StartingPrice > auctionItem.Costs)
                ? ValidationResult.Success
                : new ValidationResult("Utgångspris behöver vara högre än kostnaderna");                
        }
    }
}
