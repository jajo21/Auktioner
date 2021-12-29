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
    }
}
