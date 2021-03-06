﻿using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.DataAccess.Interface
{
    public interface IArticleDal: IGenericDal<Article>
    {
        Task<Article> GetArticleWithCategoryByUrlAsync(string url);
        Task<List<Article>> GetArticlesTop6Async();
    }
}
