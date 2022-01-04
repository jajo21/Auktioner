using System.ComponentModel.DataAnnotations;

namespace Auktioner.ViewModels
{
    public class AddItemViewModel : EditItemViewModel
    {
        public string Purchaser { get; set; }

        [Required(ErrorMessage = "Var god ange ett korrekt årtionde - exempel: 1990")]
        [Display(Name = "Skapad årtionde")]
        [RegularExpression(@"^\d{1,3}0{1}$", ErrorMessage = "Var god ange ett korrekt årtionde enligt formaten YYYY/YYY/YY och avsluta med siffran 0")]
        [Range(0, 2020, ErrorMessage = "Var god välj ett årtionde innan 2030")]
        public int Decade { get; set; }
    }
}
