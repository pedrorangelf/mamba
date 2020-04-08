using System.Collections.Generic;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;

namespace Mamba.Infra.Repositories
{
    public class DesafioRepository : RepositoryBase<Desafio>, IDesafioRepository
    {
        public DesafioRepository(ContextBase contextBase) : base(contextBase)
        {
        }

        public IEnumerable<Desafio> ListarDesafios()
        {
            return _contextBase.Desafio;
        }

        public Desafio Salvar(Desafio desafio)
        {
            _contextBase.Add(desafio);

            return desafio;
        }
    }
}
