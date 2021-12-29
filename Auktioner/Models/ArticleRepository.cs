using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auktioner.Models
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _appDbContext;
        public ArticleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Article> AllArticles
        {
            get
            {
                return _appDbContext.Articles;
            }
        }
        public IEnumerable<Article> ArticlesInStock()
        {
            return _appDbContext.Articles.Where(a => a.Sold == false);
        }
        public void AddToInventory(Article article)
        {
            article.ArticleAdded = DateTime.Now;
            _appDbContext.Articles.Add(article);
            _appDbContext.SaveChanges();
        }
    }
}
