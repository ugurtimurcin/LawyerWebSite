using AutoMapper;
using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Controllers
{
    public class WorkAreaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWorkAreaService _workAreaService;
        public WorkAreaController(IMapper mapper, IWorkAreaService workAreaService)
        {
            _mapper = mapper;
            _workAreaService = workAreaService;
        }
        [Route("calisma-alanlari")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Çalışma Alanları";
            TempData["Active"] = "workareas";            
            return View(_mapper.Map<List<WorkAreaListDto>>((await _workAreaService.GetWokrAreasWithCategoryAsync()).Data));
        }
    }
}
