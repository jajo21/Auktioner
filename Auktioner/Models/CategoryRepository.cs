using System.Collections.Generic;
using System.Linq;

namespace Auktioner.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;

        public Category GetCategoryByName(string categoryName)
        {
            return _appDbContext.Categories.FirstOrDefault(c => c.CategoryName == categoryName);
        }
        public void AddCategory(Category category)
        {
            var isCategoryInList = _appDbContext.Categories.FirstOrDefault(c => c.CategoryName == category.CategoryName);
            if (isCategoryInList == null)
            {
                int categoryId = _appDbContext.Categories.Count();
                category.CategoryId = categoryId + 1;
                _appDbContext.Categories.Add(category);
                _appDbContext.SaveChanges();
            }
        }
    }
}
