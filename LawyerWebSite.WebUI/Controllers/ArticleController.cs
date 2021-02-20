using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concretes.DTOs;
using Mapster;
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
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Makaleler";
            TempData["Active"] = "articles";
            var categories = await _categoryService.GetAllAsync();
            return View(categories.Adapt<List<CategoryListDto>>());
        }
        [Route("/makaleler/{url}")]
        public async Task<IActionResult> Articles(string url)
        {
            TempData["Active"] = "articles";
            var articles = await _categoryService.GetCategoryWithArticlesByUrlAsync(url);
            return View(articles.Adapt<CategoryAllListDto>());
        }

        [Route("/makaleler/makale/{url}")]
        public async Task<IActionResult> Detail(string url)
        {
            TempData["Active"] = "articles";
            var article = await _articleService.GetArticleWithCategoryByUrlAsync(url);
            ViewBag.Title = article.Title.ToString();
            ViewBag.Category = _categoryService.GetByIdAsync(article.CategoryId);
            var model = new ArticleListDto()
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                DateTime = article.DateTime,
                Picture = article.Picture
            };
            return View(article.Adapt<ArticleListDto>());
        }
    }
}
