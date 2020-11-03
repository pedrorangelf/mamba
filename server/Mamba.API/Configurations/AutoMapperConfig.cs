using AutoMapper;
using Mamba.API.Controllers.DTOs.Requests;
using Mamba.API.DTOs.Requests;
using Mamba.API.DTOs.Responses;
using Mamba.Domain.Entities;

namespace Mamba.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Desafio, DesafioCreateRequest>().ReverseMap();
            CreateMap<Desafio, DesafioUpdateRequest>().ReverseMap();
            CreateMap<Desafio, DesafioDetailResponse>().ReverseMap();

            CreateMap<Questao, QuestaoCreateRequest>().ReverseMap();
            CreateMap<Questao, QuestaoUpdateRequest>().ReverseMap();
            CreateMap<Questao, QuestaoDetailResponse>().ReverseMap();

            CreateMap<Empresa, EmpresaRequest>().ReverseMap();
            CreateMap<Endereco, EnderecoRequest>().ReverseMap();
            CreateMap<Endereco, EnderecoInscricaoRequest>().ReverseMap();

            CreateMap<Cargo, CargoResponse>().ReverseMap();
        }
    }
}
