using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LawyerWebSite.Business.Interface;

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

            ViewBag.TotalCategory = (await _categoryService.GetAllAsync()).Data.Count;
            ViewBag.TotalArticle = (await _articleService.GetAllAsync()).Data.Count;
            ViewBag.TotalWorkArea = (await _workAreaService.GetWokrAreasWithCategoryAsync()).Data.Count;
            ViewBag.TotalNotAssigntWorkArea = (await _categoryService.GetCategoriesWithNotSelectedWorkAreaAsync()).Data.Count;
            return View();
        }
    }
}
