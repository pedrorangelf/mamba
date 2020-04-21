using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mamba.API.AutoMapper;
using Mamba.Application;
using Mamba.Application.Interface;
using Mamba.Domain.Interfaces.Repositories;
using Mamba.Domain.Interfaces.Services;
using Mamba.Domain.Services;
using Mamba.Infra.Context;
using Mamba.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Mamba.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Definicao do Contexto
            services.AddDbContext<ContextBase>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Conexao"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Mamba",
                        Version = "v1",
                        Description = "Mamba API REST",
                        Contact = new OpenApiContact
                        {
                            Name = "Mamba",
                            Url = new Uri("https://github.com/pedrorangelf/mamba")
                        }
                    });
            });

            // INFRA
            services.AddScoped<IAreaAtuacaoRepository, AreaAtuacaoRepository>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IDesafioRepository, DesafioRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IInscricaoRepository, InscricaoRepository>();
            services.AddScoped<IQuestaoRepository, QuestaoRepository>();
            services.AddScoped<IRespostaRepository, RespostaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // DOMAIN
            services.AddScoped<IAreaAtuacaoService, AreaAtuacaoService>();
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            services.AddScoped<ICandidatoService, CandidatoService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IDesafioService, DesafioService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IInscricaoService, InscricaoService>();
            services.AddScoped<IQuestaoService, QuestaoService>();
            services.AddScoped<IRespostaService, RespostaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            // APPLICATION
            services.AddScoped<IAreaAtuacaoAppService, AreaAtuacaoAppService>();
            services.AddScoped<IAvaliacaoAppService, AvaliacaoAppService>();
            services.AddScoped<ICandidatoAppService, CandidatoAppService>();
            services.AddScoped<ICargoAppService, CargoAppService>();
            services.AddScoped<ICidadeAppService, CidadeAppService>();
            services.AddScoped<IDesafioAppService, DesafioAppService>();
            services.AddScoped<IEmpresaAppService, EmpresaAppService>();
            services.AddScoped<IEstadoAppService, EstadoAppService>();
            services.AddScoped<IFuncionarioAppService, FuncionarioAppService>();
            services.AddScoped<IInscricaoAppService, InscricaoAppService>();
            services.AddScoped<IQuestaoAppService, QuestaoAppService>();
            services.AddScoped<IRespostaAppService, RespostaAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mamba V1");
            });

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
