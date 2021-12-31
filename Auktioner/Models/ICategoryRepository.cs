using System.Collections.Generic;

namespace Auktioner.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
