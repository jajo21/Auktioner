using Auktioner.Models;
using Auktioner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            if(user.IsAuctioneer)
            {
                return View(new InventoryListViewModel
                {
                    AuctionItems = _auctionItemRepository.AuctionItemsInStock(),
                    ThisUser = user
                });;
            }
            else
            {
                return View(new InventoryListViewModel
                {
                    AuctionItems = _auctionItemRepository.SoldAuctionItems(user.UserName),
                    ThisUser = user
                });
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
                AuctionItemId = auctionItem.AuctionItemId,
                Name = auctionItem.Name,
                Description = auctionItem.Description,
                Costs = auctionItem.Costs,
                StartingPrice = auctionItem.StartingPrice,
                CategoryName = auctionItem.CategoryName,
                Categories = _categoryRepository.AllCategories,
                ThisUser = _userManager.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(User))
            });
        }

        [HttpPost]
        public IActionResult Edit(EditItemViewModel model)
        { 
            model.Categories = _categoryRepository.AllCategories;
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
            return View(model);
        }

        public IActionResult AuctioneerEdit(string itemId)
        {
            var auctionItem = _auctionItemRepository.GetAuctionItemById(itemId);
            if (auctionItem == null)
            {
                return NotFound();
            }
            return View(new AuctioneerEditViewModel
            {
                AuctionItemId = auctionItem.AuctionItemId,
                Name = auctionItem.Name,
                Description = auctionItem.Description,
                Costs = auctionItem.Costs,
                StartingPrice = auctionItem.StartingPrice,
                FinalPrice = auctionItem.FinalPrice,
                Decade = auctionItem.Decade,
                Purchaser = auctionItem.Purchaser,
                InStock = auctionItem.InStock,
                CategoryName = auctionItem.CategoryName,
                ThisUser = _userManager.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(User))
            });
        }

        [HttpPost]
        public IActionResult AuctioneerEdit(AuctioneerEditViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(User));
            model.ThisUser = user; 
            
            if (user.IsAuctioneer)
            {
                if (ModelState.IsValid)
                {
                    AuctionItem auctionItem = _auctionItemRepository.GetAuctionItemById(model.AuctionItemId);
                    auctionItem.AuctionItemId = model.AuctionItemId;
                    auctionItem.FinalPrice = model.FinalPrice;
                    auctionItem.InStock = model.InStock;

                    _auctionItemRepository.Update(auctionItem);
                    return RedirectToAction("AuctionItemUpdated");
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult AuctionItemUpdated()
        {
            ViewBag.AuctionItemUpdatedMessage = "Tack. Du har nu uppdaterat objektet!";
            return View();
        }
    }
}
