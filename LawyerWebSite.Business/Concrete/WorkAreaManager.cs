using LawyerWebSite.Business.Constants;
using LawyerWebSite.Core.Utilities.Helpers.FileHelpers;
using LawyerWebSite.Core.Utilities.Results.Abstract;
using LawyerWebSite.Core.Utilities.Results.Concrete;
using LawyerWebSite.Entities.Concrete;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LawyerWebSite.Business.Interface;
using LawyerWebSite.DataAccess.Interface;

namespace LawyerWebSite.Business.Concrete
{
    public class WorkAreaManager : IWorkAreaService
    {
        private readonly IWorkAreaDal _workArea;
        public WorkAreaManager(IWorkAreaDal workArea)
        {
            _workArea = workArea;
        }
        public async Task<IResult> AddAsync(WorkArea entity, IFormFile file)
        {
            entity.Picture = Guid.NewGuid() + Path.GetExtension(file.FileName);
            await ImageProcessHelper.UploadAsync(entity.Picture, FolderDirectories.WorkareaFolder, file);

            await _workArea.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(WorkArea entity)
        {
            ImageProcessHelper.Delete(entity.Picture);
            await _workArea.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<WorkArea>>> GetAllAsync()
        {
            return new SuccessDataResult<List<WorkArea>>(await _workArea.GetAllAsync());
        }

        public async Task<IDataResult<WorkArea>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<WorkArea>(await _workArea.GetByIdAsync(id));
        }

        public async Task<IDataResult<List<WorkAreaListDto>>> GetWokrAreasWithCategoryAsync()
        {
            return new SuccessDataResult<List<WorkAreaListDto>>( await _workArea.GetWokrAreasWithCategoryAsync());
        }

        public async Task<IResult> UpdateAsync(WorkArea entity, IFormFile file)
        {
            ImageProcessHelper.Delete(entity.Picture);

            await _workArea.UpdateAsync(entity);
            return new SuccessResult();
        }

        
    }
}
