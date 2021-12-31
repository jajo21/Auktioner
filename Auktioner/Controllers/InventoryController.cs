using Auktioner.Models;
using Auktioner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Auktioner.Controllers
{
    [Authorize] // Måste logga in för att lägga till
    public class InventoryController : Controller
    {
        private readonly IAuctionItemRepository _auctionItemRepository;
        //private readonly UserManager<AppUser> _userManager;

        public InventoryController(IAuctionItemRepository auctionItemRepository/*, UserManager<AppUser> userManager*/)
        {
            _auctionItemRepository = auctionItemRepository;
            //_userManager = userManager;
        }

        public ViewResult List()
        {
            InventoryListViewModel articleListViewModel = new();
            articleListViewModel.AuctionItems = _auctionItemRepository.AuctionItemsInStock();
            return View(articleListViewModel);
        }
        
        public IActionResult Edit(string itemId)
        {
            var selectedAuctionItem = _auctionItemRepository.AllAuctionItems.FirstOrDefault(item => item.AuctionItemId == itemId);
            return View(selectedAuctionItem);
        }
        [HttpPost]
        public IActionResult Edit(AuctionItem changedItem)
        {
            AuctionItem auctionItem = _auctionItemRepository.GetAuctionItemByID(changedItem.AuctionItemId);
            if (ModelState.IsValid)
            {
                auctionItem.Name = changedItem.Name;
                auctionItem.Description = changedItem.Description;
                auctionItem.StartingPrice = changedItem.StartingPrice;
                auctionItem.Costs = changedItem.Costs;

                _auctionItemRepository.Update(auctionItem);
                return RedirectToAction("AuctionItemUpdated");
            }
            return View(auctionItem);
        }
        public IActionResult AuctionItemUpdated()
        {
            ViewBag.AuctionItemUpdatedMessage = "Tack. Du har nu uppdaterat objektet!";
            return View();
        }
    }
}
