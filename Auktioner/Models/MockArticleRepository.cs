using System;
using System.Collections.Generic;
using System.Linq;

namespace Auktioner.Models
{
    public class MockArticleRepository : IArticleRepository
    {
        public IEnumerable<Article> AllArticles =>
            new List<Article>
            {
                new Article
                {
                    ArticleId = "ABC123456",
                    Name = "Artikel test",
                    Description = "Artikel beskrivning",
                    YearCreated = 1991,
                    StartingPrice = 1000,
                    Costs = 700,
                    CategoryId = 1
                },
                new Article
                {
                    ArticleId = "DEF789123",
                    Name = "Artikel test2",
                    Description = "Artikel beskrivning2",
                    YearCreated = 1992,
                    StartingPrice = 1100,
                    FinalPrice = 1300,
                    Costs = 800,
                    Sold = true,
                    CategoryId = 2
                }
            };

     

        public IEnumerable<Article> ArticlesInStock()
        {
            return AllArticles.Where(a => a.Sold == false);
        }   
        public void AddToInventory(Article article)
        {
            
        }
    }
}