﻿using AutoMapper;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LawyerWebSite.Business.Interface;

namespace LawyerWebSite.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles ="Member")]
    public class WorkAreaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IWorkAreaService _workAreaService;
        public WorkAreaController(IMapper mapper, ICategoryService categoryService, IWorkAreaService workAreaService)
        {
            _categoryService = categoryService;
            _workAreaService = workAreaService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "workarea";
            ViewBag.EmptyWorkAreas = (await _categoryService.GetCategoriesWithNotSelectedWorkAreaAsync()).Data;
            ViewBag.EmptyWorkAreasCount = (await _categoryService.GetCategoriesWithNotSelectedWorkAreaAsync()).Data.Count;
            
            return View(_mapper.Map<List<WorkAreaListDto>>((await _workAreaService.GetWokrAreasWithCategoryAsync()).Data));
        }


        public async Task<IActionResult> AddWorkArea()
        {
            TempData["Active"] = "workarea";
            ViewBag.Categories = new SelectList(_mapper.Map<List<CategoryListDto>>((await _categoryService.GetCategoriesWithNotSelectedWorkAreaAsync()).Data), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkArea(WorkAreaAddDto model ,IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                await _workAreaService.AddAsync(_mapper.Map<WorkArea>(model), pic);
                return RedirectToAction("Index", "WorkArea", new { area = "Member" });
            }

            return View(model);
        }

        public async Task<IActionResult> EditWorkArea(int id)
        {
            ViewBag.Categories = new SelectList(_mapper.Map<List<CategoryListDto>>((await _categoryService.GetAllAsync()).Data), "Id", "Name");

            return View(_mapper.Map<WorkAreaEditDto>((await _workAreaService.GetByIdAsync(id)).Data));
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkArea(WorkAreaEditDto model, IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                await _workAreaService.UpdateAsync(_mapper.Map<WorkArea>(model), pic);
                return RedirectToAction("Index", "WorkArea", new { area = "Member" });
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteWorkArea(int id)
        {
            await _workAreaService.DeleteAsync(new WorkArea { Id = id });
            return Json(null);
        }
    }
}
