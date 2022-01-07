using Auktioner.Models;
using FoolProof.Core;
using System.ComponentModel.DataAnnotations;

namespace Auktioner.ViewModels
{
    public class AuctioneerEditViewModel : AddItemViewModel
    {

        [Required(ErrorMessage = "Var god ange ett slutpris")]
        [DataType(DataType.Currency)]
        [Display(Name = "Slutpris")]
        [Range(0, double.MaxValue, ErrorMessage = "Slutpriset måste vara ett positivt nummer")]
        [GreaterThanOrEqualTo("StartingPrice", ErrorMessage = "Slutpriset måste vara högre eller likamed utgångspriset")]
        
        public double FinalPrice { get; set; }

        [Required(ErrorMessage = "Kryssa i om den är såld eller ej")]
        [Display(Name = "Finns kvar i lager")]
        public bool InStock { get; set; }
    }
}