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
    public class SoldController : Controller
    {
        private readonly IAuctionItemRepository _auctionItemRepository;
        private readonly UserManager<AppUser> _userManager;

        public SoldController(IAuctionItemRepository auctionItemRepository, UserManager<AppUser> userManager)
        {
            _auctionItemRepository = auctionItemRepository;
            _userManager = userManager;
        }

        public IActionResult List()
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(User));
            if(user.IsAdmin)
            {
                return View(new InventoryListViewModel
                {
                    AuctionItems = _auctionItemRepository.SoldAuctionItems()
                });      
            }
            else
            {
                if(_auctionItemRepository.AuctionItemsInStock(user.UserName).Count() == 0)
                {
                    return RedirectToAction("NoneSold");
                }
                else
                {
                    return View(new InventoryListViewModel
                    {
                        AuctionItems = _auctionItemRepository.AuctionItemsInStock(user.UserName)
                    });
                }
            }
        }
        public IActionResult NoneSold()
        {
            ViewBag.NoneSoldMessage = "Du har tyvärr inga sålda objekt ännu!";
            return View();
        }
    }
}
