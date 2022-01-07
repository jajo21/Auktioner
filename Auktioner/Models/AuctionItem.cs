using System;
using System.ComponentModel.DataAnnotations;

namespace Auktioner.Models
{
    public class AuctionItem
    {
        [Required(ErrorMessage = "Var god ange ett korrekt ID med 3 versaler och 6 siffror - exempel: ABC123456")]
        [Display(Name = "Artikel ID")]
        [RegularExpression(@"^[A-Z]{3}\d{6}$", ErrorMessage = "Var god ange ett korrekt ID med 3 versaler och 6 siffror - exempel: ABC123456")]
        [Key]
        public string AuctionItemId { get; set; }

        [Required(ErrorMessage = "Var god ange ett namn på artikeln")]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Var god ange en beskrivning av artikeln")]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Var god ange ett korrekt årtionde - exempel: 1990")]
        [Display(Name = "Skapad årtionde")]
        [RegularExpression(@"^\d{1,3}0{1}$", ErrorMessage = "Var god ange ett korrekt årtionde enligt formaten YYYY/YYY/YY och avsluta med siffran 0")]
        public int Decade { get; set; }

        [Required(ErrorMessage = "Var god ange ett utgångspris")]
        [DataType(DataType.Currency)]
        [Display(Name = "Utgångspris")]
        [Range(0, double.MaxValue, ErrorMessage = "Utgångspriset måste vara högre än kostnaderna")]
        public double StartingPrice { get; set; }

        [Required(ErrorMessage = "Var god ange ett slutpris")]
        [DataType(DataType.Currency)]
        [Display(Name = "Slutpris")]
        [Range(0, double.MaxValue, ErrorMessage = "Slutpriset måste vara ett positivt nummer")]
        public double FinalPrice { get; set; }

        [Required(ErrorMessage = "Var god ange totala kostnader för artikeln")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total kostnad")]
        [Range(0, double.MaxValue, ErrorMessage = "Kostnaden måste vara ett positivt nummer")]
        public double Costs { get; set; }

        [Required(ErrorMessage = "Kryssa i om den är såld eller ej")]
        [Display(Name = "Är artikeln såld")]
        public bool InStock { get; set; } = true;

        public string Purchaser { get; set; }
        [Required(ErrorMessage = "Välj kategori")]
        [Display(Name = "Välj kategori")]
        public string CategoryName { get; set; }
    }
}