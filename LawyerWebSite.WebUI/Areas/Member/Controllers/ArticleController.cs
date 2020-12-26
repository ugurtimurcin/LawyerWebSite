using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.WebUI.Areas.Admin.Models;
using LawyerWebSite.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly DataContext _context;
        public ArticleController(IArticleService articleService, ICategoryService categoryService, DataContext context)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _context = context;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makaleler";
            var articles = _articleService.GetAll();
            var articleModel = new List<ArticleListViewModel>();
            foreach (var article in articles)
            {
                var model = new ArticleListViewModel()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    DateTime = article.DateTime,
                    Picture = article.Picture
                };
                articleModel.Add(model);
            }
            return View(articleModel);
        }

        public IActionResult AddArticle()
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makale Ekle";
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleAddViewModel model, IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                var titleConv = new TitleConverter();
                var urlConv = new UrlConverter();

                if (pic != null)
                {
                    var extension = Path.GetExtension(pic.FileName);
                    var name = urlConv.StringReplace(model.Title) + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/article-cover/" + name);
                    using var stream = new FileStream(path, FileMode.Create);
                    await pic.CopyToAsync(stream);
                    model.Picture = name;

                }

                var article = new Article()
                {
                    Title = titleConv.TitleToPascalCase(model.Title),
                    Content = model.Content.Replace("&nbsp;", " "),
                    CategoryId = model.CategoryId,
                    Url = urlConv.StringReplace(model.Title),
                    Picture = model.Picture
                };
                if (_context.Articles.Any(x=>x.Title == model.Title))
                {
                    ViewBag.TitleExist = titleConv.TitleToPascalCase(model.Title);
                    return View(model);
                }
                _articleService.Create(article);
                return RedirectToAction("Index", "Article", new { area="Member" });

            }
            return View(model);
        }

        public IActionResult EditArticle(int id)
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makale Düzenle";
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            var article = _articleService.GetById(id);
            var model = new ArticleEditViewModel()
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CategoryId = article.CategoryId,
                Picture = article.Picture
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(ArticleEditViewModel model, IFormFile pic)
        {
            var article = _articleService.GetById(model.Id);

            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            if (ModelState.IsValid)
            {
                var titleConv = new TitleConverter();
                var urlConv = new UrlConverter();

                if (pic != null)
                {
                    var extension = Path.GetExtension(pic.FileName);
                    var name = urlConv.StringReplace(model.Title) + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/article-cover/" + name);
                    using var stream = new FileStream(path, FileMode.Create);
                    await pic.CopyToAsync(stream);
                    model.Picture = name;
                    article.Picture = model.Picture;

                }
                article.Title = titleConv.TitleToPascalCase(model.Title);
                article.Content = model.Content.Replace("&nbsp;", " ");
                article.Url = urlConv.StringReplace(model.Title);
                article.CategoryId = model.CategoryId;
                _articleService.Update(article);

                return RedirectToAction("Index", "Article", new { area = "Member" });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteArticle(int id)
        {
            _articleService.Delete(new Article { Id = id });
            return Json(null);
        }
    }
}
