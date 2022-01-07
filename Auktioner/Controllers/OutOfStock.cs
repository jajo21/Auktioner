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
    public class OutOfStock : Controller
    {
        private readonly IAuctionItemRepository _auctionItemRepository;
        private readonly UserManager<AppUser> _userManager;

        public OutOfStock(IAuctionItemRepository auctionItemRepository, UserManager<AppUser> userManager)
        {
            _auctionItemRepository = auctionItemRepository;
            _userManager = userManager;
        }

        public IActionResult List()
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(User));
            if(user.IsAuctioneer)
            {
                return View(new InventoryListViewModel
                {
                    AuctionItems = _auctionItemRepository.SoldAuctionItems(),
                    ThisUser = user
                });      
            }
            else
            {
                if(_auctionItemRepository.AuctionItemsInStock(user.UserName).Count() == 0)
                {
                    return RedirectToAction("NoneSoldOutOfStock");
                }
                else
                {
                    return View(new InventoryListViewModel
                    {
                        AuctionItems = _auctionItemRepository.AuctionItemsInStock(user.UserName),
                        ThisUser = user
                    });
                }
            }
        }
        public IActionResult NoneSoldOutOfStock()
        {
            ViewBag.NoneSoldOutOfStockMessage = "Du har tyvärr inga sålda objekt som har lämnat lagret ännu!";
            return View();
        }
    }
}
