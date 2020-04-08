using System.Collections.Generic;
using Mamba.Domain.Entities;

namespace Mamba.Domain.Interfaces.Repositories
{
    public interface IDesafioRepository : IRepositoryBase<Desafio>
    {
        IEnumerable<Desafio> ListarDesafios();
        Desafio Salvar(Desafio desafio);
        void Excluir(int id);
        Desafio BuscarPorId(int id);

    }
}
