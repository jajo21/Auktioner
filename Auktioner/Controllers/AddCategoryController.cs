using Auktioner.Models;
using Auktioner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Auktioner.Controllers
{
    [Authorize]
    public class AddCategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Add()
        {
            AddCategoryViewModel model = new();
            model.Categories = _categoryRepository.AllCategories;
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel model)
        {

            if (ModelState.IsValid)
            {
                Category category = new()
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                };
                _categoryRepository.AddCategory(category);
                return RedirectToAction("CategoryAdded");
            }
            model.Categories = _categoryRepository.AllCategories;
            return View(model);
        }

        public IActionResult CategoryAdded()
        {
            ViewBag.CategoryAddedMessage = "Tack. Du har nu lagt till en kategori!";
            return View();
        }

        //[HttpPost]
        //public IActionResult DeleteCategory(int categoryId)
        //{
        //    var cat = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == categoryId);
        //    if (ModelState.IsValid)
        //    {
        //        _categoryRepository.RemoveCategory(cat);
        //        return RedirectToAction("CategoryAdded");
        //    }
        //    return View(categoryId);
        //}
    }
}
