using Auktioner.Models;
using Auktioner.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Auktioner.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public InventoryController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public ViewResult List()
        {
            InventoryListViewModel articleListViewModel = new();
            articleListViewModel.Articles = _articleRepository.ArticlesInStock();
            return View(articleListViewModel);
        }

        // FÖR ATT LÄGGA TILL INVETARIER
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Article article)
        {
            if(ModelState.IsValid)
            {
                _articleRepository.AddToInventory(article);
                return RedirectToAction("ArticleAdded");
            }
            return View(article);
        }

        public IActionResult ArticleAdded()
        {
            ViewBag.ArticleAddedMessage = "Tack. Du har nu lagt till artikeln till inventarierna!";
            return View();
        }

    }
}
