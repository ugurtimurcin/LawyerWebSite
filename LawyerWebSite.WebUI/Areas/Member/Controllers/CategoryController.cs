﻿using AutoMapper;
using LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawyerWebSite.Business.Interface;

namespace LawyerWebSite.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "category";
            ViewBag.Title = "Kategoriler";

            return View(_mapper.Map<List<CategoryListDto>>((await _categoryService.GetAllAsync()).Data));
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

                await _categoryService.AddAsync(_mapper.Map<Category>(model));
                return RedirectToAction("Index", "Category", new { area = "Member" });

            }
            return View(model);
        }

        public async Task<IActionResult> EditCategory(int id)
        {
            TempData["Active"] = "category";
            ViewBag.Title = "Kategori Düzenle";
            
            return View(_mapper.Map<CategoryEditDto>((await _categoryService.GetByIdAsync(id)).Data));
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryEditDto model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(_mapper.Map<Category>(model));

                return RedirectToAction("Index","Category", new { area = "Member" });
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
