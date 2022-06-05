using Auktioner.Models;
using FoolProof.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auktioner.ViewModels
{
    public class EditItemViewModel
    {
        [Required(ErrorMessage = "Var god ange ett korrekt ID med 3 versaler och 6 siffror - exempel: ABC123456")]
        [Display(Name = "Objekt ID")]
        [RegularExpression(@"^[A-Z]{3}\d{6}$", ErrorMessage = "Var god ange ett korrekt ID med 3 versaler och 6 siffror - exempel: ABC123456")]
        [Key]
        public string AuctionItemId { get; set; }

        [Required(ErrorMessage = "Var god ange ett namn på artikeln")]
        [Display(Name = "Rubrik")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Var god ange en beskrivning av artikeln")]
        [Display(Name = "Objektsbeskrivning")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Var god ange totala kostnader för artikeln")]
        [DataType(DataType.Currency)]
        [Display(Name = "Objektskostnad")]
        [Range(0, double.MaxValue, ErrorMessage = "Kostnaden måste vara ett positivt nummer")]
        [LessThan("StartingPrice", ErrorMessage = "Kostnaden måste vara lägre än utgångspriset")]
        public double Costs { get; set; }

        [Required(ErrorMessage = "Var god ange ett utgångspris")]
        [DataType(DataType.Currency)]
        [Display(Name = "Utgångspris")]
        [Range(0, double.MaxValue, ErrorMessage = "Utgångspriset måste vara högre än kostnaderna")]
        [GreaterThan("Costs", ErrorMessage = "Utgångspriset måste vara högre än kostnaderna")]
        public double StartingPrice { get; set; }

        [Required(ErrorMessage = "Välj kategori")]
        [Display(Name = "Välj kategori")]
        public string CategoryName { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public AppUser ThisUser {get; set;}
    }
}
