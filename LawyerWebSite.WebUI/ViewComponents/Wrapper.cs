using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concretes.DTOs;
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
            var articlesModel = new List<ArticleListDto>();
            var articles = _articleservice.GetArticlesTop6();
            foreach (var item in articles)
            {
                var articleMdl = new ArticleListDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    DateTime = item.DateTime,
                    Picture = item.Picture,
                    Url = item.Url
                };
                articlesModel.Add(articleMdl);
            }
            ViewBag.Articles = articlesModel;

            var workareasModel = new List<WorkAreaListViewDto>();
            var workareas = _workAreaService.GetWokrAreasWithCategory();
            foreach (var item in workareas)
            {
                var workareaMdl = new WorkAreaListViewDto()
                {
                    Category = item.Category,
                    Description = item.Desciption,
                    Picture = item.Picture
                };

                workareasModel.Add(workareaMdl);
            }
            ViewBag.WorkAreas = workareasModel;

            return View();
        }
    }
}
