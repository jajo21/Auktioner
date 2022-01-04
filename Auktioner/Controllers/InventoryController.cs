using Auktioner.Models;
using Auktioner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Auktioner.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly IAuctionItemRepository _auctionItemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<AppUser> _userManager;

        public InventoryController(IAuctionItemRepository auctionItemRepository, ICategoryRepository categoryRepository, UserManager<AppUser> userManager)
        {
            _auctionItemRepository = auctionItemRepository;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
        }

        public ViewResult List()
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(User));
            
            if(user.IsAdmin)
            {
                InventoryListViewModel model = new();
                model.AuctionItems = _auctionItemRepository.AuctionItemsInStock();
                return View(model);
            }
            else
            {
                InventoryListViewModel model = new();
                model.AuctionItems = _auctionItemRepository.AllAuctionItems.Where(i => i.Purchaser == user.UserName);
                return View(model);
            }
        }
        
        public IActionResult Edit(string itemId)
        {
            var auctionItem = _auctionItemRepository.GetAuctionItemById(itemId);
            if(auctionItem == null)
            {
                return NotFound();
            }
            return View(new EditItemViewModel
            {
                AuctionItemId = itemId,
                Name = auctionItem.Name,
                Description = auctionItem.Description,
                Costs = auctionItem.Costs,
                StartingPrice = auctionItem.StartingPrice,
                CategoryName = auctionItem.CategoryName,
                Categories = _categoryRepository.AllCategories
            });
        }

        [HttpPost]
        public IActionResult Edit(EditItemViewModel model)
        { 
            if (ModelState.IsValid)
            {
                AuctionItem auctionItem = _auctionItemRepository.GetAuctionItemById(model.AuctionItemId);
                auctionItem.Name = model.Name;
                auctionItem.Description = model.Description;
                auctionItem.StartingPrice = model.StartingPrice;
                auctionItem.Costs = model.Costs;
                auctionItem.CategoryName = model.CategoryName;

                _auctionItemRepository.Update(auctionItem);
                return RedirectToAction("AuctionItemUpdated");
            }
            model.Categories = _categoryRepository.AllCategories;
            return View(model);
        }
        public IActionResult AuctionItemUpdated()
        {
            ViewBag.AuctionItemUpdatedMessage = "Tack. Du har nu uppdaterat objektet!";
            return View();
        }
    }
}
