using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.WebUI.Areas.Admin.Models;
using LawyerWebSite.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly DataContext _context;
        public CategoryController(ICategoryService categoryService, DataContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "category";
            ViewBag.Title = "Kategoriler";
            var categories = _categoryService.GetAll();
            var categoryModel = new List<CategoryListViewModel>();
            foreach (var category in categories)
            {
                var model = new CategoryListViewModel()
                {
                    Id = category.Id,
                    Name = category.Name
                };
                categoryModel.Add(model);
            }
            return View(categoryModel);
        }

        public IActionResult AddCategory()
        {
            TempData["Active"] = "category";
            ViewBag.Title = "Kategori Ekle";
            return View(new CategoryAddViewModel());
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryAddViewModel model)
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
                if (_context.Categories.Any(x=>x.Name == model.Name))
                {
                    ViewBag.CategoryExsit = titleConverter.TitleToPascalCase(model.Name);
                    return View(model);
                }

                _categoryService.Create(category);
                return RedirectToAction("Index", "Category", new { area = "Member" });

            }
            return View(model);
        }

        public IActionResult EditCategory(int id)
        {
            TempData["Active"] = "category";
            ViewBag.Title = "Kategori Düzenle";
            var category = _categoryService.GetById(id);
            var model = new CategoryEditViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                Url = category.Url
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var convertor = new UrlConverter();
                var titleConvertor = new TitleConverter();
                var category = _categoryService.GetById(model.Id);
                category.Name = titleConvertor.TitleToPascalCase(model.Name);
                category.Url = convertor.StringReplace(model.Name);

                _categoryService.Update(category);

                return RedirectToAction("Index","Category", new { area = "Member" });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(new Category { Id = id });
            return Json(null);
        }
    }
}
