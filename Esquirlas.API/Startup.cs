using Esquirlas.Application.Interfaces;
using Esquirlas.Application.Services;
using Esquirlas.Application.Validator;
using Esquirlas.Domain.Entities;
using Esquirlas.Infrastructure;
using Esquirlas.Infrastructure.Interfaces;
using Esquirlas.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;


namespace Esquirlas.API
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
            /// Add Context Personalizado
            services.AddDbContext<DataContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("Sql"),
                    builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));

            /// Add Controllers
            services.AddControllers();

            /// Add Services
            services.AddTransient<IPersonajesServices, PersonajesServices>();

            /// Add Repositories
            services.AddTransient<IPersonajesRepository, PersonajesRepository>();

            /// Add FluentValidation
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PersonajeValidator>());

            /// Add Automapper
            services.AddAutoMapper(typeof(Personaje));

            /// Add Swagger Personalizado
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Esquirlas.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                /// Swagger personalizado
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Esquirlas.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                /// Endpoint Controller
                endpoints.MapControllers();
                
            });
        }
    }
}
