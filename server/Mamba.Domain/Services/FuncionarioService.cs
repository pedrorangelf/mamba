using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Interfaces;
using System.Threading.Tasks;
using System;

namespace Mamba.Domain.Services
{
    public class FuncionarioService : ServiceBase<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly INotificator _notificator;

        public FuncionarioService(IFuncionarioRepository FuncionarioRepository, INotificator notificator) : base(FuncionarioRepository, notificator)
        {
            _funcionarioRepository = FuncionarioRepository;
            _notificator = notificator;
        }

        public async Task<Funcionario> ObterFuncionarioUsuario(Guid idUsuario)
        {
            return await _funcionarioRepository.ObterFuncionarioUsuario(idUsuario);
        }
    }
}
