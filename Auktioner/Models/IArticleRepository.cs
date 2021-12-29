using System.Collections.Generic;

namespace Auktioner.Models
{
    public interface IArticleRepository
    {
        IEnumerable<Article> AllArticles { get; }
        public IEnumerable<Article> ArticlesInStock();
    }
}
