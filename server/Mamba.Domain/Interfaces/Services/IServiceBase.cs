using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mamba.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
        Task RemoveInScale(IEnumerable<TEntity> objs);
        Task<TEntity> GetById(int id);
        Task<TEntity> FindAsNoTracking(int id);
        Task<IEnumerable<TEntity>> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<int> SaveChanges();
    }
}
