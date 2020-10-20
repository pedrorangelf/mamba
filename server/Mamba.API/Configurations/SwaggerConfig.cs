using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Mamba.API.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {apiToken}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                options.EnableAnnotations();
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Mamba API {description.GroupName.ToUpperInvariant()}");
                }
            });

            return app;
        }


        public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
            {
                _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
            }

            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }

            private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
            {
                var info = new OpenApiInfo
                {
                    Title = "API - mamba.io",
                    Version = description.ApiVersion.ToString(),
                    Description = "Api de consumo sobre o projeto do StartUp One da FIAP ON. mamba.io ",
                    Contact = new OpenApiContact { Email = "dev@mamba.io", Name = "Suporte para Devs" }
                };

                if (description.IsDeprecated)
                    info.Description += " Esta versão está obsoleta e será abandonada em breve!";

                return info;
            }
        }

        public class SwaggerDefaultValues : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                operation.Deprecated = context.ApiDescription.IsDeprecated();

                if (operation.Parameters == null) return;

                foreach (var parameter in operation.Parameters)
                {
                    var description = context.ApiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                    if (parameter.Description == null)
                    {
                        parameter.Description = description.ModelMetadata?.Description;
                    }

                    var routeInfo = description.RouteInfo;
                    if (routeInfo == null) continue;

                    if (parameter.In != ParameterLocation.Path && parameter.Schema.Default == null)
                    {
                        parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());
                    }

                    parameter.Required |= !routeInfo.IsOptional;
                }
            }
        }
    }
}
