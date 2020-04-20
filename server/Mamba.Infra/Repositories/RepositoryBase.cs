using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mamba.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ContextBase _contextBase;

        public RepositoryBase(ContextBase contextBase)
        {
            _contextBase = contextBase;
        }

        public void Add(TEntity obj)
        {
            _contextBase.Set<TEntity>().Add(obj);
            _contextBase.SaveChanges();
        }

        public TEntity FindAsNoTracking(int id)
        {
            TEntity genericEntity = _contextBase.Set<TEntity>().Find(id);

            _contextBase.Entry(genericEntity).State = EntityState.Detached;

            return genericEntity;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _contextBase.Set<TEntity>().AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _contextBase.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return _contextBase.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _contextBase.Set<TEntity>().Remove(obj);
            _contextBase.SaveChanges();
        }

        public void RemoveInScale(IEnumerable<TEntity> objs)
        {
            foreach (var obj in objs)
            {
                _contextBase.Set<TEntity>().Remove(obj);
                _contextBase.SaveChanges();
            }
        }

        public void Update(TEntity obj)
        {
            _contextBase.Entry(obj).State = EntityState.Modified;
            _contextBase.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDispose)
        {
            if (!isDispose) return;
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }
    }
}
