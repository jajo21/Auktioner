using System.Collections.Generic;
using Auktioner.Models;

namespace Auktioner.ViewModels
{
    public class InventoryListViewModel
    {
        IEnumerable<Article> articles;
        public IEnumerable<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}
