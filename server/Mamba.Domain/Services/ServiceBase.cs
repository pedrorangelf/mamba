using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mamba.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task Add(TEntity obj)
        {
            await _repositoryBase.Add(obj);
        }

        public async Task Update(TEntity obj)
        {
            await _repositoryBase.Update(obj);
        }

        public async Task Remove(TEntity obj)
        {
            await _repositoryBase.Remove(obj);
        }

        public async Task RemoveInScale(IEnumerable<TEntity> objs)
        {
            await _repositoryBase.RemoveInScale(objs);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repositoryBase.GetById(id);
        }

        public async Task<TEntity> FindAsNoTracking(int id)
        {
            return await _repositoryBase.FindAsNoTracking(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repositoryBase.GetAll();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repositoryBase.FindBy(predicate, includes);
        }

        public async Task<int> SaveChanges()
        {
            return await _repositoryBase.SaveChanges();
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }
    }
}
