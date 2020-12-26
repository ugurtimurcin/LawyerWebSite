using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        public ArticleController(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }

        [Route("/makaleler/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Makaleler";
            TempData["Active"] = "articles";
            var categories = _categoryService.GetAll();
            var models = new List<CategoryListViewModel>();
            foreach (var category in categories)
            {
                var model = new CategoryListViewModel()
                {
                    Id = category.Id,
                    Url = category.Url,
                    Name = category.Name
                };
                models.Add(model);
            }
            return View(models);
        }
        [Route("/makaleler/{url}")]
        public IActionResult Articles(string url)
        {
            TempData["Active"] = "articles";
            var articles = _categoryService.GetCategoryWithArticlesByUrl(url);
            var model = new CategoryAllListViewModel()
            {
                Id = articles.Id,
                Name = articles.Name,
                Articles = articles.Articles
            };

            ViewBag.Title = model.Name;
            return View(model);
        }

        [Route("/makaleler/makale/{url}")]
        public IActionResult Detail(string url)
        {
            TempData["Active"] = "articles";
            var article = _articleService.GetArticleWithCategoryByUrl(url);
            ViewBag.Title = article.Title.ToString();
            ViewBag.Category = _categoryService.GetById(article.CategoryId);
            var model = new ArticleListViewModel()
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                DateTime = article.DateTime,
                Picture = article.Picture
            };
            return View(model);
        }
    }
}
