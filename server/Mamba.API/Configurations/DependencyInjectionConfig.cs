using Mamba.API.Extensions;
using Mamba.Domain.Interfaces;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Notifications;
using Mamba.Domain.Services;
using Mamba.Infra.Context;
using Mamba.Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using static Mamba.API.Configurations.SwaggerConfig;

namespace Mamba.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDepedencies(this IServiceCollection services)
        {
            services.AddScoped<ContextBase>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IUser, UserApp>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // INFRA
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IDesafioRepository, DesafioRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IInscricaoRepository, InscricaoRepository>();
            services.AddScoped<IQuestaoRepository, QuestaoRepository>();
            services.AddScoped<IRespostaRepository, RespostaRepository>();

            // DOMAIN
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            services.AddScoped<ICandidatoService, CandidatoService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IDesafioService, DesafioService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IInscricaoService, InscricaoService>();
            services.AddScoped<IQuestaoService, QuestaoService>();
            services.AddScoped<IRespostaService, RespostaService>();

            return services;
        }
    }
}
