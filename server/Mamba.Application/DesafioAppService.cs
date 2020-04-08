using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class DesafioAppService : AppServiceBase<Desafio>, IDesafioAppService
    {
        private readonly IDesafioService _DesafioService;

        public DesafioAppService(IDesafioService DesafioService) : base(DesafioService)
        {
            _DesafioService = DesafioService;
        }
    }
}
