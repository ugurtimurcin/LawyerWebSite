using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.Concretes
{
    public class WorkAreaManager : IWorkAreaService
    {
        private readonly IWorkAreaDal _workArea;
        public WorkAreaManager(IWorkAreaDal workArea)
        {
            _workArea = workArea;
        }
        public void Create(WokrArea entity)
        {
            _workArea.Create(entity);
        }

        public void Delete(WokrArea entity)
        {
            _workArea.Delete(entity);
        }

        public List<WokrArea> GetAll()
        {
            return _workArea.GetAll();
        }

        public WokrArea GetById(int id)
        {
            return _workArea.GetById(id);
        }

        public List<WokrArea> GetWokrAreasWithCategory()
        {
            return _workArea.GetWokrAreasWithCategory();
        }

        public void Update(WokrArea entity)
        {
            _workArea.Update(entity);
        }
    }
}
