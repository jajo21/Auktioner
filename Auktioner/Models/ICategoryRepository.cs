using System.Collections.Generic;

namespace Auktioner.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        Category GetCategoryByName(string categoryName);
        void AddCategory(Category category);
        void RemoveCategory(Category category);
    }
}
