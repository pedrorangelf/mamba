using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
        Task RemoveInScale(IEnumerable<TEntity> objs);
        Task<TEntity> GetById(Guid id);
        Task<TEntity> FindAsNoTracking(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<int> SaveChanges();
    }
}
