using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.Infra.Repositories
{
    public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(ContextBase contextBase) : base(contextBase)
        {
        }
    }
}
