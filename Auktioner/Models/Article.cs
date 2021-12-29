using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace Auktioner.Models
{
    public class Article
    {
        
        string articleId; //3 bokstäver och 6 siffror
        string name;
        string description;
        int yearCreated;
        double startingPrice; // får aldrig vara lägre än costs
        double finalPrice;
        double costs; 
        bool sold = false;
        int categoryId;
        DateTime articleAdded;

        [Required(ErrorMessage = "Var god ange ett korrekt ID med 3 bokstäver och 6 siffror - exempel: ABC123456")]
        [Display(Name = "Artikel ID")]
        [StringLength(9, MinimumLength = 9)]
        public string ArticleId
        {
            get { return this.articleId; }
            set { this.articleId = value; }
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

        [Required(ErrorMessage = "Var god ange ett korrekt årtal - exempel: 1991")]
        [Display(Name = "Skapad år (format YYYY)")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public int YearCreated
        {
            get { return this.yearCreated; }
            set { this.yearCreated = value; }    
        }

        [Required(ErrorMessage = "Var god ange ett utgångspris")]
        [DataType(DataType.Currency)]
        [Display(Name = "Utgångspris")]
        [Range(0, int.MaxValue, ErrorMessage = "Utgångspriset måste vara ett positivt nummer")]
        public double StartingPrice
        {
            get { return this.startingPrice; }
            set { this.startingPrice = value; }
        }

        [Required(ErrorMessage = "Var god ange ett slutpris")]
        [DataType(DataType.Currency)]
        [Display(Name = "Slutpris")]
        [Range(0, int.MaxValue, ErrorMessage = "Slutpriset måste vara ett positivt nummer")]
        public double FinalPrice
        {
            get { return this.finalPrice; }
            set { this.finalPrice = value; }
        }

        [Required(ErrorMessage = "Var god ange totala kostnader för artikeln")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total kostnad för artikel")]
        [Range(0, int.MaxValue, ErrorMessage = "Kostnaden måste vara ett positivt nummer")]
        public double Costs
        {
            get { return this.costs; }
            set { this.costs = value; }
        }
        [Required(ErrorMessage = "Kryssa i om den är såld eller ej")]
        [Display(Name = "Är artikeln såld")]
        public bool Sold
        {
            get { return this.sold; }
            set { this.sold = value; }
        }
        public int CategoryId
        {
            get { return this.categoryId; }
            set { this.categoryId = value; }
        }
        public DateTime ArticleAdded
        {
            get { return this.articleAdded; }
            set { this.articleAdded = value; }
        }
    }
}