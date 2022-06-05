using Auktioner.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auktioner.ViewModels
{
    public class AddCategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Var god ange ett namn på kategorin")]
        [Display(Name = "Kategori")]
        [StringLength(50, ErrorMessage = "Kategorin får inte vara längre än 50 tecken")]
        public string CategoryName { get; set; }
    }
}
