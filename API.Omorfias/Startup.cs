using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using API.Omorfias.AppServices.Profiles.Omorfias;
using API.Omorfias.Data.Base;
using API.Omorfias.Data.Interfaces;
using API.Omorfias.Data.Repositories.Core;
using API.Omorfias.Domain.Base.Configuration;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using API.Omorfias.Domain.Base.Interfaces.Repositories;
using API.Omorfias.Domain.Base.Services;
using API.Omorfias.Domain.Handler;
using API.Omorfias.Domain.Interfaces.Configuracoes;
using API.Omorfias.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API.Omorfias
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
            var configuracoes = new ConfigurationBuilder()
                                     .SetBasePath(Directory.GetCurrentDirectory())
                                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                     .Build();
            configuracoes.Reload();

            InicializarConfiguracoes(configuracoes, out IGerenciadorDeConfiguracoes gerenciadorDeConfiguracoes);
            AdicionarAssembliesParaAutoMapper(services);

            services.AddControllers();

            AdicionarTransients(services, gerenciadorDeConfiguracoes);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Omorfias",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "API Verticais");
            });
        }
        private void AdicionarTransients(IServiceCollection services, IGerenciadorDeConfiguracoes gerenciadorDeConfiguracoes)
        {
            AdicionarScoped(services);

            AdicionarTransients(services);

            services.AddDbContext<OmorfiasContext>(options =>
            {
                options.UseSqlServer(gerenciadorDeConfiguracoes.ObterValor<string>("IlangSQL"), sqlServerOptions => sqlServerOptions.CommandTimeout(gerenciadorDeConfiguracoes.ObterValor<int>("BancoTimeout")));
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
                options.UseLoggerFactory(OmorfiasContext.LoggerFactory);
            });

        }
        private static void AdicionarScoped(IServiceCollection services)
        {
            services.AddScoped(typeof(IHandler<DomainNotification>), typeof(DomainNotificationHandler));
        }
        private static void AdicionarTransients(IServiceCollection services)
        {
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddTransient(typeof(IGerenciadorDeConfiguracoes), typeof(GerenciadorDeConfiguracoes));
            services.AddTransient(typeof(IService<,>), typeof(Service<,>));
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
        }
        private static void AdicionarAssembliesParaAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(OmorfiasProfile).GetTypeInfo().Assembly);
        }

        private void InicializarConfiguracoes(IConfigurationRoot configuracoes, out IGerenciadorDeConfiguracoes gerenciadorDeConfiguracoes)
        {
            gerenciadorDeConfiguracoes = new GerenciadorDeConfiguracoes();

            InserirConfiguracoesPorNo(configuracoes, "AppConfiguration", gerenciadorDeConfiguracoes);
            CompletarConfiguracoesComKeyVaultSecrets(configuracoes, gerenciadorDeConfiguracoes);
        }
        private void CompletarConfiguracoesComKeyVaultSecrets(IConfigurationRoot configuracoes, IGerenciadorDeConfiguracoes gerenciadorDeConfiguracoes)
        {
            InserirConfiguracoesPorNo(configuracoes, "DevConfiguration", gerenciadorDeConfiguracoes);
        }

        private void InserirConfiguracoesPorNo(IConfigurationRoot configuracoes, string no, IGerenciadorDeConfiguracoes gerenciadorDeConfiguracoes)
        {
            IConfigurationSection secaoConfiguracoes = configuracoes.GetSection(no);
            IEnumerable<IConfigurationSection> configuracoesFilhas = secaoConfiguracoes.GetChildren();
            gerenciadorDeConfiguracoes.InserirRegistros(configuracoesFilhas.Select(_secao => new KeyValuePair<string, string>(_secao.Key, _secao.Value)));
        }
    }
}
