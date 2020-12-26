using LawyerWebSite.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.Interfaces
{
    public interface IGenericService<T> where T: class, ITable, new()
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
