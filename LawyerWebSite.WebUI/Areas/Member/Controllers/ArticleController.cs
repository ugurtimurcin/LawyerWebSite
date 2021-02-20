using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.Entities.Concretes.DTOs;
using LawyerWebSite.Entities.Concretes.Entities;
using LawyerWebSite.WebUI.Extensions;
using Mapster;
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
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makaleler";
            var articles = await _articleService.GetAllAsync();

            return View(articles.Adapt<List<ArticleListDto>>());
        }

        public async Task<IActionResult> AddArticle()
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makale Ekle";
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleEditDto model, IFormFile pic)
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
                await _articleService.AddAsync(article);
                return RedirectToAction("Index", "Article", new { area="Member" });

            }
            return View(model);
        }

        public async Task<IActionResult> EditArticle(int id)
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makale Düzenle";
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            var article = _articleService.GetByIdAsync(id);
           
            return View(article.Adapt<ArticleEditDto>());
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(ArticleEditDto model, IFormFile pic)
        {
            var article = await _articleService.GetByIdAsync(model.Id);

            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
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
                await _articleService.UpdateAsync(article);

                return RedirectToAction("Index", "Article", new { area = "Member" });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleService.DeleteAsync(new Article { Id = id });
            return Json(null);
        }
    }
}
