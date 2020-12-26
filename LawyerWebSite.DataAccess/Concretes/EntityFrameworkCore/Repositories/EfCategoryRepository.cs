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
    public class EfCategoryRepository : EfGenericRepository<Category, DataContext>, ICategoryDal
    {
        public List<Category> GetCategoriesWithNotSelectedWorkArea()
        {
            using var context = new DataContext();
            return context.Categories.Include(x => x.WokrArea).Where(x => x.WokrArea.Desciption == null).ToList();
        }

        public List<Category> GetCategoriesWithWorkArea()
        {
            using var context = new DataContext();
            return context.Categories.Include(x => x.WokrArea).ToList();
        }

        public Category GetCategoryWithArticlesById(int id)
        {
            using var context = new DataContext();
            return context.Categories.Include(a => a.Articles).Where(S => S.Id == id).FirstOrDefault();
        }

        public Category GetCategoryWithArticlesByUrl(string url)
        {
            using var context = new DataContext();
            return context.Categories.Include(a => a.Articles).Where(a => a.Url == url).FirstOrDefault();
        }
    }
}
