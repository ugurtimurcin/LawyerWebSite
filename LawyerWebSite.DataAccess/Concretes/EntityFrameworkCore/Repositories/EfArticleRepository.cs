using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Repositories
{
    public class EfArticleRepository : EfGenericRepository<Article, DataContext>, IArticleDal
    {
        public List<Article> GetArticlesTop6()
        {
            using var context = new DataContext();
            return context.Articles.OrderByDescending(x => x.DateTime).Take(6).ToList();
        }

        public Article GetArticleWithCategoryByUrl(string url)
        {
            using var context = new DataContext();
            return context.Articles.Include(a => a.Category).Where(a => a.Url == url).FirstOrDefault();
        }
    }
}
