using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concrete.DTOs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Controllers
{
    public class WorkAreaController : Controller
    {
        private readonly IWorkAreaService _workAreaService;
        public WorkAreaController(IWorkAreaService workAreaService)
        {
            _workAreaService = workAreaService;
        }
        [Route("calisma-alanlari")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Çalışma Alanları";
            TempData["Active"] = "workareas";

            var workareas = await _workAreaService.GetWokrAreasWithCategoryAsync();
            
            return View(workareas.Adapt<List<WorkAreaListDto>>());
        }
    }
}
