using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.Entities.Concretes.DTOs;
using LawyerWebSite.Entities.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Concretes
{
    public class WorkAreaManager : IWorkAreaService
    {
        private readonly IWorkAreaDal _workArea;
        public WorkAreaManager(IWorkAreaDal workArea)
        {
            _workArea = workArea;
        }
        public async Task AddAsync(WorkArea entity)
        {
            await _workArea.AddAsync(entity);
        }

        public async Task DeleteAsync(WorkArea entity)
        {
            await _workArea.DeleteAsync(entity);
        }

        public async Task<List<WorkArea>> GetAllAsync()
        {
            return await _workArea.GetAllAsync();
        }

        public async Task<WorkArea> GetByIdAsync(int id)
        {
            return await _workArea.GetByIdAsync(id);
        }

        public async Task<List<WorkAreaListDto>> GetWokrAreasWithCategoryAsync()
        {
            return await _workArea.GetWokrAreasWithCategoryAsync();
        }

        public async Task UpdateAsync(WorkArea entity)
        {
            await _workArea.UpdateAsync(entity);
        }
    }
}
