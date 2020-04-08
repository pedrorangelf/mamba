using System.Collections.Generic;
using System.Linq;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Mamba.Infra.Repositories
{
    public class DesafioRepository : RepositoryBase<Desafio>, IDesafioRepository
    {
        public DesafioRepository(ContextBase contextBase) : base(contextBase)
        {
        }

        public Desafio BuscarPorId(int id)
        {
            try
            {
                return _contextBase.Desafio.Include(i => i.Questoes).FirstOrDefault(f => f.IdDesafio == id);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                IEnumerable<Questao> questoes = _contextBase.Questao.Where(w => w.Desafio.IdDesafio == id);
                _contextBase.Questao.RemoveRange(questoes);
                Desafio desafio = _contextBase.Desafio.FirstOrDefault(f => f.IdDesafio == id);
                _contextBase.Desafio.Remove(desafio);
                _contextBase.SaveChanges();

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Desafio> ListarDesafios()
        {
            return _contextBase.Desafio;
        }

        public Desafio Salvar(Desafio desafio)
        {
            Desafio retorno = _contextBase.Desafio.Add(desafio).Entity;
            _contextBase.SaveChanges();

            return retorno;
        }
    }
}
