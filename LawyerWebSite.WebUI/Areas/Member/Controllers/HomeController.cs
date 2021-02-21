using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly IWorkAreaService _workAreaService;
        public HomeController(ICategoryService categoryService, IArticleService articleService, IWorkAreaService workAreaService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            _workAreaService = workAreaService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "home";
            ViewBag.Title = "Anasayfa";

            ViewBag.TotalCategory = (await _categoryService.GetAllAsync()).Count;
            ViewBag.TotalArticle = (await _articleService.GetAllAsync()).Count;
            ViewBag.TotalWorkArea = (await _workAreaService.GetWokrAreasWithCategoryAsync()).Count;
            ViewBag.TotalNotAssigntWorkArea = (await _categoryService.GetCategoriesWithNotSelectedWorkAreaAsync()).Count;
            return View();
        }
    }
}
