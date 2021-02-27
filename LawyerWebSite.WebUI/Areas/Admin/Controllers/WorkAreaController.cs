using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "workarea";
            ViewBag.EmptyWorkAreas = await _categoryService.GetCategoriesWithNotSelectedWorkAreaAsync();
            ViewBag.EmptyWorkAreasCount = (await _categoryService.GetCategoriesWithNotSelectedWorkAreaAsync()).Count;

            var workareas = await _workAreaService.GetWokrAreasWithCategoryAsync();
            return View(workareas.Adapt<List<WorkAreaListDto>>());
        }


        public async Task<IActionResult> AddWorkArea()
        {
            TempData["Active"] = "workarea";
            ViewBag.Categories = new SelectList(await _categoryService.GetCategoriesWithNotSelectedWorkAreaAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkArea(WorkAreaAddDto model ,IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                if (pic != null)
                {
                    var extension = Path.GetExtension(pic.FileName);
                    var name = (await _categoryService.GetByIdAsync(model.CategoryId)).Url + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/workarea-cover/" + name);
                    using var stream = new FileStream(path, FileMode.Create);
                    await pic.CopyToAsync(stream);
                    model.Picture = name;
                }

                var workArea = new WorkArea()
                {
                    Desciption = model.Description.Replace("&nbsp;"," "),
                    Picture = model.Picture,
                    CategoryId = model.CategoryId
                };

                await _workAreaService.AddAsync(workArea);
                return RedirectToAction("Index", "WorkArea", new { area = "Admin" });
            }

            return View(model);
        }

        public async Task<IActionResult> EditWorkArea(int id)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            var workarea = _workAreaService.GetByIdAsync(id);

            return View(workarea.Adapt<WorkAreaEditDto>());
        }

        [HttpPost]
        public async Task<IActionResult> EditWorkArea(WorkAreaEditDto model, IFormFile pic)
        {
            var workarea = await _workAreaService.GetByIdAsync(model.Id);
            if (ModelState.IsValid)
            {
                if (pic != null)
                {
                    var extension = Path.GetExtension(pic.FileName);
                    var picName = (await _categoryService.GetByIdAsync(model.CategoryId)).Url + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/workarea-cover/" + picName);
                    using var stream = new FileStream(path, FileMode.Create);
                    await pic.CopyToAsync(stream);

                    model.Picture = picName;

                    workarea.Picture = model.Picture;
                }

                workarea.Desciption = model.Description.Replace("&nbsp;", " ");
                workarea.CategoryId = model.CategoryId;

                await _workAreaService.UpdateAsync(workarea);
                return RedirectToAction("Index", "WorkArea", new { area = "Admin" });
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
