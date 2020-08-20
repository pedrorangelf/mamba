﻿using AutoMapper;
using Mamba.API.DTOs;
using Mamba.Domain.Entities;

namespace Mamba.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AreaAtuacao, AreaAtuacaoViewModel>().ReverseMap();
            CreateMap<Avaliacao, AvaliacaoViewModel>().ReverseMap();
            CreateMap<Candidato, CandidatoViewModel>().ReverseMap();
            CreateMap<Cargo, CargoViewModel>().ReverseMap();
            CreateMap<Cidade, CidadeViewModel>().ReverseMap();
            CreateMap<Desafio, DesafioViewModel>().ReverseMap();
            CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
            CreateMap<Estado, EstadoViewModel>().ReverseMap();
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
            CreateMap<Inscricao, InscricaoViewModel>().ReverseMap();
            CreateMap<Questao, QuestaoViewModel>().ReverseMap();
            CreateMap<Resposta, RespostaViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}