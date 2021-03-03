using LawyerWebSite.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.Core.DataAccess
{
    public class EfGenericRepository<TEntity, TContext> : IGenericDal<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new TContext();
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new TContext();
            await Task.Run(() => { context.Set<TEntity>().Remove(entity); });
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            using var context = new TContext();
            return predicate == null ? await context.Set<TEntity>().ToListAsync() : await context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using var context = new TContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new TContext();
            await Task.Run(() => { context.Set<TEntity>().Update(entity); });
            await context.SaveChangesAsync();
        }
    }
}
