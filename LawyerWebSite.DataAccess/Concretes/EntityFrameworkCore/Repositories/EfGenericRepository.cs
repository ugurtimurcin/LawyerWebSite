using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity, TContext> : IGenericDal<TEntity> where TEntity : class, ITable, new() where TContext : DataContext, new()
    {
        public void Create(TEntity entity)
        {
            using var context = new DataContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new DataContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            using var context = new DataContext();
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            using var context = new DataContext();
            return context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            using var context = new DataContext();
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
