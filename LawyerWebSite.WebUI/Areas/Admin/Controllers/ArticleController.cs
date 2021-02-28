using AutoMapper;
using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
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

namespace LawyerWebSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ArticleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        public ArticleController(IMapper mapper, IArticleService articleService, ICategoryService categoryService)
        {
            _mapper = mapper;
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makaleler";

            return View(_mapper.Map<List<ArticleListDto>>(await _articleService.GetAllAsync()));
        }
        public async Task<IActionResult> AddArticle()
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makale Ekle";
            ViewBag.Categories = new SelectList(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllAsync()), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleAddDto model, IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                
                await _articleService.AddAsync(_mapper.Map<Article>(model), pic);
                return RedirectToAction("Index", "Article", new { area = "Admin" });

            }
            return View(model);
        }
        public async Task<IActionResult> EditArticle(int id)
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makale Düzenle";
            ViewBag.Categories = new SelectList(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllAsync()), "Id", "Name");
            
            return View(_mapper.Map<ArticleEditDto>(await _articleService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(ArticleEditDto model, IFormFile pic)
        {
            var article = await _articleService.GetByIdAsync(model.Id);
            if (ModelState.IsValid)
            {
                await _articleService.UpdateAsync(_mapper.Map<Article>(model), pic);

                return RedirectToAction("Index", "Article", new { area = "Admin" });
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
