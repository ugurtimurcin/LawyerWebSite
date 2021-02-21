using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.Entities.Concretes.DTOs;
using LawyerWebSite.Entities.Concretes.Entities;
using LawyerWebSite.WebUI.Extensions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly DataContext _context;
        public CategoryController(ICategoryService categoryService, DataContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "category";
            ViewBag.Title = "Kategoriler";

            var categories = await _categoryService.GetAllAsync();

            return View(categories.Adapt<List<CategoryListDto>>());
        }

        public IActionResult AddCategory()
        {
            TempData["Active"] = "category";
            ViewBag.Title = "Kategori Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddDto model)
        {
            if (ModelState.IsValid)
            {
                var urlConvertor = new UrlConverter();
                var titleConverter = new TitleConverter();
                
                var category = new Category()
                {
                    Name = titleConverter.TitleToPascalCase(model.Name),
                    Url = urlConvertor.StringReplace(model.Name.ToLower())
                };
                if (_context.Categories.Any(x => x.Name == model.Name))
                {
                    ViewBag.ExistCategory = titleConverter.TitleToPascalCase(model.Name);
                    return View(model);
                }

                await _categoryService.AddAsync(category);
                return RedirectToAction("Index", "Category", new { area = "Admin" });

            }
            return View(model);
        }

        public async Task<IActionResult> EditCategory(int id)
        {
            TempData["Active"] = "category";
            ViewBag.Title = "Kategori Düzenle";
            var category = await _categoryService.GetByIdAsync(id);

            return View(category.Adapt<CategoryEditDto>());
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryEditDto model)
        {
            if (ModelState.IsValid)
            {
                var convertor = new UrlConverter();
                var titleConvertor = new TitleConverter();
                var category = await _categoryService.GetByIdAsync(model.Id);
                category.Name = titleConvertor.TitleToPascalCase(model.Name);
                category.Url = convertor.StringReplace(model.Name);

                await _categoryService.UpdateAsync(category);

                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteAsync(new Category { Id = id });
            return Json(null);
        }
    }
}
