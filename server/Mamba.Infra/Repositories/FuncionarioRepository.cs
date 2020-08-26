using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mamba.Infra.Repositories
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ContextBase contextBase) : base(contextBase) { }


        public async Task<Funcionario> ObterFuncionarioUsuario(Guid idUsuario)
        {
            return await _contextBase.Funcionario.AsNoTracking()
                            .FirstOrDefaultAsync(f => f.ApplicationUserId == idUsuario);
        }
    }
}
