using LawyerWebSite.Business.Constants;
using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Core.Business;
using LawyerWebSite.Core.Utilities.Converter;
using LawyerWebSite.Core.Utilities.Helpers.FileHelpers;
using LawyerWebSite.Core.Utilities.Results.Abstract;
using LawyerWebSite.Core.Utilities.Results.Concrete;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }
        public async Task<IResult> AddAsync(Article entity, IFormFile file)
        {
            IResult result = BusinessRules.Run(await ArticleAlreadyExists(entity.Title));
            if (result != null)
            {
                return result;
            }

            entity.Picture = Guid.NewGuid() + Path.GetExtension(file.FileName);
            await ImageProcessHelper.UploadAsync(entity.Picture, FolderDirectories.ArticleFolder, file);

            entity.Title = StringHelper.TitleToPascalCase(entity.Title);
            entity.Url = StringHelper.FriendlyUrl(entity.Title);

            await _articleDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Article entity)
        {
            ImageProcessHelper.Delete(entity.Picture);

            await _articleDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Article>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Article>>(await _articleDal.GetAllAsync());
        }

        public async Task<IDataResult<List<Article>>> GetArticlesTop6Async()
        {
            return new SuccessDataResult<List<Article>>(await _articleDal.GetArticlesTop6Async());
        }

        public async Task<IDataResult<Article>> GetArticleWithCategoryByUrlAsync(string url)
        {
            return new SuccessDataResult<Article>(await _articleDal.GetArticleWithCategoryByUrlAsync(url));
        }

        public async Task<IDataResult<Article>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Article>(await _articleDal.GetByIdAsync(id));
        }

        public async Task<IResult> UpdateAsync(Article entity, IFormFile file)
        {
            ImageProcessHelper.Delete(entity.Picture);

            entity.Picture = Guid.NewGuid() + Path.GetExtension(file.FileName);
            await ImageProcessHelper.UploadAsync(entity.Picture, FolderDirectories.ArticleFolder, file);

            entity.Title = StringHelper.TitleToPascalCase(entity.Title);
            entity.Url = StringHelper.FriendlyUrl(entity.Title);

            await _articleDal.UpdateAsync(entity);
            return new SuccessResult();
        }

        private async Task<IResult> ArticleAlreadyExists(string title)
        {
            var result = (await _articleDal.GetAllAsync(x => x.Title == title)).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryAlreadyExists);
            }
            return new SuccessResult();
        }

    }
}
