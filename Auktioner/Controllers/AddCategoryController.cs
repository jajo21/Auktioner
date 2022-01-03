using Auktioner.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auktioner.Controllers
{
    public class AddCategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(category);
                return RedirectToAction("CategoryAdded");
            }
            return View(category);
        }

        public IActionResult CategoryAdded()
        {
            ViewBag.CategoryAddedMessage = "Tack. Du har nu lagt till en kategori!";
            return View();
        }
    }
}
