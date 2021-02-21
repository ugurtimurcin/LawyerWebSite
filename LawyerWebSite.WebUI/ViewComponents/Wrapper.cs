using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concretes.DTOs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.ViewComponents
{
    public class Wrapper: ViewComponent
    {
        private readonly IArticleService _articleservice;
        private readonly IWorkAreaService _workAreaService;
        public Wrapper(IArticleService articleservice, IWorkAreaService workAreaService)
        {
            _articleservice = articleservice;
            _workAreaService = workAreaService;
        }
        public IViewComponentResult Invoke()
        {
            var articles = _articleservice.GetArticlesTop6Async().Result;
            ViewBag.Articles = articles.Adapt<List<ArticleListDto>>();

            var workareas = _workAreaService.GetWokrAreasWithCategoryAsync().Result;
            ViewBag.WorkAreas = workareas.Adapt<List<WorkAreaListViewDto>>();

            return View();
        }
    }
}
