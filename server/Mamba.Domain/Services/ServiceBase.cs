using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mamba.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(TEntity obj)
        {
            _repositoryBase.Add(obj);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public TEntity FindAsNoTracking(int id)
        {
            return _repositoryBase.FindAsNoTracking(id);
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repositoryBase.FindBy(predicate, includes);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _repositoryBase.Remove(obj);
        }

        public void RemoveInScale(IEnumerable<TEntity> objs)
        {
            _repositoryBase.RemoveInScale(objs);
        }

        public void Update(TEntity obj)
        {
            _repositoryBase.Update(obj);
        }
    }
}
