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

        public string ArticleId
        {
            get { return this.articleId; }
            set { this.articleId = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public int YearCreated
        {
            get { return this.yearCreated; }
            set { this.yearCreated = value; }    
        }
        public double StartingPrice
        {
            get { return this.startingPrice; }
            set { this.startingPrice = value; }
        }
        public double FinalPrice
        {
            get { return this.finalPrice; }
            set { this.finalPrice = value; }
        }
        public double Costs
        {
            get { return this.costs; }
            set { this.costs = value; }
        }
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
    }
}