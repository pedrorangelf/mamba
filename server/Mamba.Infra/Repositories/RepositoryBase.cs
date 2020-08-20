using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mamba.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ContextBase _contextBase;
        protected readonly DbSet<TEntity> _entity;

        public RepositoryBase(ContextBase contextBase)
        {
            _contextBase = contextBase;
            _entity = contextBase.Set<TEntity>();
        }

        public async Task Add(TEntity obj)
        {
            _entity.Add(obj);
            await SaveChanges();
        }

        public async Task Update(TEntity obj)
        {
            _entity.Update(obj);
            await SaveChanges();
        }

        public async Task Remove(TEntity obj)
        {
            _entity.Remove(obj);
            await SaveChanges();
        }

        public async Task RemoveInScale(IEnumerable<TEntity> objs)
        {
            foreach (var obj in objs)
            {
                _entity.Remove(obj);
                await SaveChanges();
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<TEntity> FindAsNoTracking(int id)
        {
            var entity = await _entity.FindAsync(id);

            if (entity != null) _contextBase.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _entity.AsNoTracking();

            if (predicate != null) query = query.Where(predicate);

            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }


        public async Task<int> SaveChanges()
        {
            return await _contextBase.SaveChangesAsync();
        }

        public void Dispose()
        {
            _contextBase?.Dispose();
        }
    }
}
