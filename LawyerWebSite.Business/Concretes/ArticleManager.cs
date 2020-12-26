using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.Concretes
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }
        public void Create(Article entity)
        {
            _articleDal.Create(entity);
        }

        public void Delete(Article entity)
        {
            _articleDal.Delete(entity);
        }

        public List<Article> GetAll()
        {
            return _articleDal.GetAll();
        }

        public List<Article> GetArticlesTop6()
        {
            return _articleDal.GetArticlesTop6();
        }

        public Article GetArticleWithCategoryByUrl(string url)
        {
            return _articleDal.GetArticleWithCategoryByUrl(url);
        }

        public Article GetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public void Update(Article entity)
        {
            _articleDal.Update(entity);
        }
    }
}
