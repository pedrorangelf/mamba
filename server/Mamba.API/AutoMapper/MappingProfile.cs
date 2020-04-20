using AutoMapper;
using Mamba.API.Model;
using Mamba.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmpresaModel, Empresa>();
            CreateMap<Empresa, EmpresaModel>();

            CreateMap<UsuarioModel, Usuario>();
            CreateMap<Usuario, UsuarioModel>();
        }
    }
}
