using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.WebUI.Areas.Admin.Models;
using LawyerWebSite.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    [Authorize(Roles ="Admin")]
    public class WorkAreaController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IWorkAreaService _workAreaService;
        public WorkAreaController(ICategoryService categoryService, IWorkAreaService workAreaService)
        {
            _categoryService = categoryService;
            _workAreaService = workAreaService;

        }
        public IActionResult Index()
        {
            TempData["Active"] = "workarea";
            ViewBag.EmptyWorkAreas = _categoryService.GetCategoriesWithNotSelectedWorkArea();
            ViewBag.EmptyWorkAreasCount = _categoryService.GetCategoriesWithNotSelectedWorkArea().Count;
            var workareas = _workAreaService.GetWokrAreasWithCategory();
            var model = new List<WorkAreaListViewModel>();
            foreach (var item in workareas)
            {
                var mdl = new WorkAreaListViewModel()
                {
                    Id = item.Id,
                    Description = item.Desciption,
                    Category = item.Category,
                    Picture = item.Picture
                };
                model.Add(mdl);
            }
            return View(model);
        }


        public IActionResult AddWorkArea()
        {
            TempData["Active"] = "workarea";
            ViewBag.Categories = new SelectList(_categoryService.GetCategoriesWithNotSelectedWorkArea(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkArea(WorkAreaAddViewModel model ,IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                if (pic != null)
                {
                    var extension = Path.GetExtension(pic.FileName);
                    var name = _categoryService.GetById(model.CategoryId).Url + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/workarea-cover/" + name);
                    using var stream = new FileStream(path, FileMode.Create);
                    await pic.CopyToAsync(stream);
                    model.Picture = name;
                }

                var workArea = new WokrArea()
                {
                    Desciption = model.Description.Replace("&nbsp;"," "),
                    Picture = model.Picture,
                    CategoryId = model.CategoryId
                };

                _workAreaService.Create(workArea);
                return RedirectToAction("Index", "WorkArea", new { area = "Admin" });
            }

            return View(model);
        }

        public IActionResult EditWorkArea(int id)
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "Name");
            var workarea = _workAreaService.GetById(id);
            var model = new WorkAreaEditViewModel()
            {
                Id = workarea.Id,
                Description = workarea.Desciption,
                Picture = workarea.Picture,
                CategoryId = workarea.CategoryId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkArea(WorkAreaEditViewModel model, IFormFile pic)
        {
            var workarea = _workAreaService.GetById(model.Id);
            if (ModelState.IsValid)
            {
                if (pic != null)
                {
                    var extension = Path.GetExtension(pic.FileName);
                    var picName = _categoryService.GetById(model.CategoryId).Url + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/workarea-cover/" + picName);
                    using var stream = new FileStream(path, FileMode.Create);
                    await pic.CopyToAsync(stream);

                    model.Picture = picName;

                    workarea.Picture = model.Picture;
                }

                workarea.Desciption = model.Description.Replace("&nbsp;", " ");
                workarea.CategoryId = model.CategoryId;

                _workAreaService.Update(workarea);
                return RedirectToAction("Index", "WorkArea", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        public IActionResult DeleteWorkArea(int id)
        {
            _workAreaService.Delete(new WokrArea { Id = id });
            return Json(null);
        }
    }
}
