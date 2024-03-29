﻿using Auktioner.Models;
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
            model.Categories = _categoryRepository.AllCategories;
            var categoryExists = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == model.CategoryName);
            if(categoryExists != null)
            {
                ViewBag.CategoryNameExists = "Kategorin finns redan, testa en annan";
                return View(model);
            }

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
            return View(model);
        }

        public IActionResult CategoryAdded()
        {
            ViewBag.CategoryAddedMessage = "Tack. Du har nu lagt till en kategori!";
            return View();
        }
    }
}
