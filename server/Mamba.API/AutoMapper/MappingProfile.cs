using AutoMapper;
using Mamba.API.Model;
using Mamba.Domain.Entities;

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
