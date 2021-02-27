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

            var workareas = _workAreaService.GetWokrAreasWithCategoryAsync().Result;
            var workList = workareas.Adapt<List<WorkAreaListDto>>();
            ViewBag.WorkAreas = workList;

            var articles = _articleservice.GetArticlesTop6Async().Result;
            var list = articles.Adapt<List<ArticleListDto>>();
            ViewBag.Articles = list;

            //var workList = new List<WorkAreaListViewDto>();
            //foreach (var item in workareas)
            //{
            //    var model = new WorkAreaListViewDto()
            //    {
            //        Category = item.Category,
            //        Description = item.Desciption,
            //        Picture = item.Picture,
            //        Id = item.Id
            //    };
            //}
            return View();
        }
    }
}
