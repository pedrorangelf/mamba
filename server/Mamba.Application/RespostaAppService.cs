﻿using Mamba.Application.Interface;
using Mamba.Domain.Entities;
using Mamba.Domain.Interfaces.Services;

namespace Mamba.Application
{
    public class RespostaAppService : AppServiceBase<Resposta>, IRespostaAppService
    {
        private readonly IRespostaService _respostaService;

        public RespostaAppService(IRespostaService RespostaService) : base(RespostaService)
        {
            _respostaService = RespostaService;
        }
    }
}
