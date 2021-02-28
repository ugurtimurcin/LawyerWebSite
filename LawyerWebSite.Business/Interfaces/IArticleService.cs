﻿using LawyerWebSite.Core.Utilities.Results.Abstract;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Interfaces
{
    public interface IArticleService
    {
        Task<IResult> AddAsync(Article entity, IFormFile file);
        Task<IResult> UpdateAsync(Article entity, IFormFile file);
        Task<IResult> DeleteAsync(Article entity);
        Task<IDataResult<Article>> GetByIdAsync(int id);
        Task<IDataResult<List<Article>>> GetAllAsync();
        Task<IDataResult<Article>> GetArticleWithCategoryByUrlAsync(string url);
        Task<IDataResult<List<Article>>> GetArticlesTop6Async();
    }
}
