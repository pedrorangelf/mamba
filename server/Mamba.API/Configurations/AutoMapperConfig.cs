using AutoMapper;
using Mamba.API.DTOs;
using Mamba.API.DTOs.Domain;
using Mamba.Domain.Entities;

namespace Mamba.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Avaliacao, AvaliacaoViewModel>().ReverseMap();
            CreateMap<Candidato, CandidatoViewModel>().ReverseMap();
            CreateMap<Cargo, CargoViewModel>().ReverseMap();
            CreateMap<Desafio, DesafioViewModel>().ReverseMap();

            CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
            CreateMap<Empresa, EmpresaDto>().ReverseMap();

            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();

            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
            CreateMap<Inscricao, InscricaoViewModel>().ReverseMap();
            CreateMap<Questao, QuestaoViewModel>().ReverseMap();
            CreateMap<Resposta, RespostaViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
        }
    }
}
