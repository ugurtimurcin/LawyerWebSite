using AutoMapper;
using LawyerWebSite.Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawyerWebSite.Business.Interface;

namespace LawyerWebSite.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        public ArticleController(IMapper mapper, ICategoryService categoryService, IArticleService articleService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _articleService = articleService;
        }

        [Route("/makaleler/")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Makaleler";
            TempData["Active"] = "articles";
            return View(_mapper.Map<List<CategoryListDto>>((await _categoryService.GetAllAsync()).Data));
        }
        [Route("/makaleler/{url}")]
        public async Task<IActionResult> Articles(string url)
        {
            TempData["Active"] = "articles";
            return View(_mapper.Map<CategoryAllListDto>((await _categoryService.GetCategoryWithArticlesByUrlAsync(url)).Data));
        }

        [Route("/makaleler/makale/{url}")]
        public async Task<IActionResult> Detail(string url)
        {
            TempData["Active"] = "articles";
            var article = await _articleService.GetArticleWithCategoryByUrlAsync(url);
            ViewBag.Title = article.Data.Title.ToString();
            ViewBag.Category = _categoryService.GetByIdAsync(article.Data.CategoryId);
            
            return View(_mapper.Map<List<ArticleListDto>>((await _articleService.GetArticleWithCategoryByUrlAsync(url)).Data));
        }
    }
}
