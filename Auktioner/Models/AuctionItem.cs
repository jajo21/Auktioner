using Auktioner.CustomValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace Auktioner.Models
{
    public class AuctionItem
    {
        
        string auctionItemId; //3 bokstäver och 6 siffror
        string name;
        string description;
        int decade;
        double startingPrice; // får aldrig vara lägre än costs
        double finalPrice;
        double costs; 
        bool inStock = true;
        int categoryId;
        Category category;

        [Required(ErrorMessage = "Var god ange ett korrekt ID med 3 bokstäver och 6 siffror - exempel: ABC123456")]
        [Display(Name = "Artikel ID - exempel: ABC123456")]
        [RegularExpression(@"^[A-Za-z]{3}\d{6}$", ErrorMessage = "Var god ange ett korrekt ID med 3 bokstäver och 6 siffror - exempel: ABC123456")]
        public string AuctionItemId
        {
            get { return this.auctionItemId; }
            set { this.auctionItemId = value; }
        }

        [Required(ErrorMessage = "Var god ange ett namn på artikeln")]
        [Display(Name = "Namn")]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [Required(ErrorMessage = "Var god ange en beskrivning av artikeln")]
        [Display(Name = "Beskrivning")]
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        [Required(ErrorMessage = "Var god ange ett korrekt årtionde - exempel: 1990")]
        [Display(Name = "Skapad årtionde (format YYYY)")]
        [RegularExpression(@"^\d{3}0{1}$", ErrorMessage = "Var god ange ett korrekt årtal enligt formatet YYYY och avsluta med 0")]
        public int Decade
        {
            get { return this.decade; }
            set { this.decade = value; }    
        }

        [Required(ErrorMessage = "Var god ange ett utgångspris")]
        [DataType(DataType.Currency)]
        [Display(Name = "Utgångspris")]
        [Range(1, double.MaxValue, ErrorMessage = "Utgångspriset måste vara högre än kostnaderna")]
        [StartPriceHigherThanCosts]
        public double StartingPrice
        {
            get { return this.startingPrice; }
            set {  this.startingPrice = value; }
        }

        [Required(ErrorMessage = "Var god ange ett slutpris")]
        [DataType(DataType.Currency)]
        [Display(Name = "Slutpris")]
        [Range(0, double.MaxValue, ErrorMessage = "Slutpriset måste vara ett positivt nummer")]
        public double FinalPrice
        {
            get { return this.finalPrice; }
            set { this.finalPrice = value; }
        }

        [Required(ErrorMessage = "Var god ange totala kostnader för artikeln")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total kostnad")]
        [Range(0, double.MaxValue, ErrorMessage = "Kostnaden måste vara ett positivt nummer")]
        [StartPriceHigherThanCosts]
        public double Costs
        {
            get { return this.costs; }
            set { this.costs = value; }
        }
        [Required(ErrorMessage = "Kryssa i om den är såld eller ej")]
        [Display(Name = "Är artikeln såld")]
        public bool InStock
        {
            get { return this.inStock; }
            set { this.inStock = value; }
        }
        public int CategoryId
        {
            get { return this.categoryId; }
            set { this.categoryId = value; }
        }
        public Category Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
    }
}