using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
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
        public async Task AddAsync(WokrArea entity)
        {
            await _workArea.AddAsync(entity);
        }

        public async Task DeleteAsync(WokrArea entity)
        {
            await _workArea.DeleteAsync(entity);
        }

        public async Task<List<WokrArea>> GetAllAsync()
        {
            return await _workArea.GetAllAsync();
        }

        public async Task<WokrArea> GetByIdAsync(int id)
        {
            return await _workArea.GetByIdAsync(id);
        }

        public async Task<List<WokrArea>> GetWokrAreasWithCategoryAsync()
        {
            return await _workArea.GetWokrAreasWithCategoryAsync();
        }

        public async Task UpdateAsync(WokrArea entity)
        {
            await _workArea.UpdateAsync(entity);
        }
    }
}
