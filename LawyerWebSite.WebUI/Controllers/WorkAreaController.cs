using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index()
        {
            ViewBag.Title = "Çalışma Alanları";
            TempData["Active"] = "workareas";
            var model = new List<WorkAreaListViewModel>();
            var workareas = _workAreaService.GetWokrAreasWithCategory();
            foreach (var item in workareas)
            {
                var mdl = new WorkAreaListViewModel()
                {
                    Category = item.Category,
                    Description = item.Desciption,
                    Picture = item.Picture
                };

                model.Add(mdl);
            }
            return View(model);
        }
    }
}
