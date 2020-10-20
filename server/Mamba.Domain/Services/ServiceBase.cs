using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Notifications;
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
        private readonly INotificator _notificator;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase,
                           INotificator notificator)
        {
            _repositoryBase = repositoryBase;
            _notificator = notificator;
        }

        protected void Notificar(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }
        protected bool PossuiNotificacao()
        {
            return _notificator.HasNotification();
        }

        public virtual async Task Add(TEntity obj)
        {
            if (PossuiNotificacao())
                return;

            await _repositoryBase.Add(obj);
        }

        public virtual async Task Update(TEntity obj)
        {
            if (PossuiNotificacao())
                return;

            await _repositoryBase.Update(obj);
        }

        public virtual async Task Remove(TEntity obj)
        {
            if (PossuiNotificacao())
                return;

            await _repositoryBase.Remove(obj);
        }

        public async Task RemoveInScale(IEnumerable<TEntity> objs)
        {
            if (PossuiNotificacao())
                return;

            await _repositoryBase.RemoveInScale(objs);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _repositoryBase.GetById(id);
        }

        public async Task<TEntity> FindAsNoTracking(Guid id)
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
