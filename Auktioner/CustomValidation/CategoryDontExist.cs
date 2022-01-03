using Auktioner.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Auktioner.CustomValidation
{
    public class CategoryDontExist : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var category = (Category)validationContext.ObjectInstance;

            return (category.CategoryName != null)
                ? ValidationResult.Success
                : new ValidationResult("Utgångspris behöver vara högre än kostnaderna");
        }
    }
}