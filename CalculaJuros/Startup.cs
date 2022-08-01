using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Domain.Services;
using CalculaJuros.Entities.Entidades;
using CalculaJuros.Middleware;
using CalculaJuros.Repository;
using CalculaJuros.Repository.Interfaces;
using CalculaJuros.Repository.Profiles;
using CalculaJuros.Repository.Repositorys;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CalculaJuros
{
    [ExcludeFromCodeCoverage]
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

            var conexaostring = Configuration.GetValue<string>("DBConnection");
            services.AddDbContext<CalculaJurosContext>(options =>
                 options.UseSqlServer(conexaostring));
            
            services.AddAutoMapper(typeof(JurosHistoricoConsultaProfile));
            services.AddScoped<IJurosCompostoRepository, JurosCompostoRepository>();

            services.AddScoped<IJurosComposto, JurosCompostoService>();
            services.AddScoped<IShowMeTheCode, ShowMeTheCodeService>();
            services.AddScoped<IValidator<ParametrosCalculaJuros>, ParametrosCalculaJurosValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Meu Swagger ", Version = "v1" });
            });
            services.AddControllers();
            //services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(
                opt =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Meu swagger v1");
                    opt.RoutePrefix = String.Empty;
                });

            app.UseRouting();
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature?.Error; // Your exception

                        if (exception != default)
                        {
                            // var code = 500; // Internal Server Error by default

                            if (exception is ValidationException)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                var message = ((ValidationException)exception).Errors.Any() ? ((ValidationException)exception).Errors.Select(c => c.ErrorMessage) : new List<string> { exception.Message };
                                await context.Response.WriteAsJsonAsync(new { Error =  string.Join($" {Environment.NewLine} ", message) });
                            }
                        }
                    }
                });
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
