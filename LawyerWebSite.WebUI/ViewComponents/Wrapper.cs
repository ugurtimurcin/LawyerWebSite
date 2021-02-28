using AutoMapper;
using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LawyerWebSite.WebUI.ViewComponents
{
    public class Wrapper: ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleservice;
        private readonly IWorkAreaService _workAreaService;
        public Wrapper(IMapper mapper, IArticleService articleservice, IWorkAreaService workAreaService)
        {
            _mapper = mapper;
            _articleservice = articleservice;
            _workAreaService = workAreaService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.WorkAreas = _mapper.Map<List<WorkAreaListDto>>((_workAreaService.GetWokrAreasWithCategoryAsync().Result).Data);

            ViewBag.Articles = _mapper.Map<List<ArticleListDto>>((_articleservice.GetArticlesTop6Async().Result).Data);

            return View();
        }
    }
}
