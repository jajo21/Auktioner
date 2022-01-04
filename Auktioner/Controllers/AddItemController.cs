using Auktioner.Models;
using Auktioner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Auktioner.Controllers
{
    [Authorize]
    public class AddItemController : Controller
    {
        private readonly IAuctionItemRepository _auctionItemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<AppUser> _userManager;

        public AddItemController(IAuctionItemRepository auctionItemRepository, ICategoryRepository categoryRepository, UserManager<AppUser> userManager)
        {
            _auctionItemRepository = auctionItemRepository;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
        }
        public IActionResult Add()
        {
            AddItemViewModel model = new();
            model.Categories = _categoryRepository.AllCategories;
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                AuctionItem auctionItem = new()
                {
                    AuctionItemId = model.AuctionItemId,
                    Name = model.Name,
                    Description = model.Description,
                    Costs = model.Costs,
                    StartingPrice = model.StartingPrice,
                    Decade = model.Decade,
                    Purchaser = _userManager.GetUserName(User),
                    CategoryName = model.CategoryName
                };
                _auctionItemRepository.AddToInventory(auctionItem);
                return RedirectToAction("AuctionItemAdded");
            }
            model.Categories = _categoryRepository.AllCategories;
            return View(model);
        }

        public IActionResult AuctionItemAdded()
        {
            ViewBag.AuctionItemAddedMessage = "Tack. Du har nu lagt till objektet i inventarierna!";
            return View();
        }
    }
}
