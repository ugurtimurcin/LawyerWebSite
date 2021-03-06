﻿using AutoMapper;
using LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LawyerWebSite.Business.Interface;

namespace LawyerWebSite.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ArticleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly DataContext _context;
        public ArticleController(IMapper mapper, IArticleService articleService, ICategoryService categoryService, DataContext context)
        {
            _mapper = mapper;
            _articleService = articleService;
            _categoryService = categoryService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makaleler";

            return View(_mapper.Map<List<ArticleListDto>>((await _articleService.GetAllAsync()).Data));
        }

        public async Task<IActionResult> AddArticle()
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makale Ekle";
            ViewBag.Categories = new SelectList(_mapper.Map<List<CategoryListDto>>((await _categoryService.GetAllAsync()).Data), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleAddDto model, IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                await _articleService.AddAsync(_mapper.Map<Article>(model), pic);
                return RedirectToAction("Index", "Article", new { area="Member" });

            }
            return View(model);
        }

        public async Task<IActionResult> EditArticle(int id)
        {
            TempData["Active"] = "article";
            ViewBag.Title = "Makale Düzenle";
            ViewBag.Categories = new SelectList(_mapper.Map<List<CategoryListDto>>((await _categoryService.GetAllAsync()).Data), "Id", "Name");
           
            return View(_mapper.Map<ArticleEditDto>((await _articleService.GetByIdAsync(id)).Data));
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(ArticleEditDto model, IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                await _articleService.UpdateAsync(_mapper.Map<Article>(model), pic);

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
