using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void RemoveInScale(IEnumerable<TEntity> objs);
        TEntity GetById(int id);
        TEntity FindAsNoTracking(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

    }
}
