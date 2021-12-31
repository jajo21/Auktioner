using Auktioner.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auktioner.Controllers
{
    public class AddItemController : Controller
    {
        private readonly IAuctionItemRepository _auctionItemRepository;


        public AddItemController(IAuctionItemRepository auctionItemRepository/*, UserManager<AppUser> userManager*/)
        {
            _auctionItemRepository = auctionItemRepository;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AuctionItem auctionItem)
        {
            if (ModelState.IsValid)
            {
                _auctionItemRepository.AddToInventory(auctionItem);
                return RedirectToAction("AuctionItemAdded");
            }
            return View(auctionItem);
        }

        public IActionResult AuctionItemAdded()
        {
            ViewBag.AuctionItemAddedMessage = "Tack. Du har nu lagt till artikeln till inventarierna!";
            return View();
        }
    }
}
