using System.Collections.Generic;

namespace Auktioner.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        public Category GetCategoryByName(string categoryName);
        public void AddCategory(Category category);
        public void RemoveCategory(Category category);
    }
}
