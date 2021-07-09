using Esquirlas.Application.AutoMappers;
using Esquirlas.Application.Interfaces;
using Esquirlas.Application.Services;
using Esquirlas.Application.Validator;
using Esquirlas.Domain.Entities;
using Esquirlas.Infrastructure;
using Esquirlas.Infrastructure.Interfaces;
using Esquirlas.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Net;

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
            services.AddTransient<IFaccionesServices, FaccionesServices>();
            services.AddTransient<IUsersServices, UsersServices>();

            /// Add Repositories
            services.AddTransient<IPersonajesRepository, PersonajesRepository>();
            services.AddTransient<IFaccionesRepository, FaccionesRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            /// Add FluentValidation
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PersonajeValidator>());            

            /// Add Automapper
            services.AddAutoMapper(typeof(MappPersonajes));
            services.AddAutoMapper(typeof(MappFacciones));
            services.AddAutoMapper(typeof(MappUsers));

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
            else
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; ;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                        {
                            await context.Response.WriteAsync(
                                                      "File error thrown!<br><br>\r\n");
                        }

                        await context.Response.WriteAsync(
                                                      "<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512));
                    });
                });
                app.UseHsts();
            }

            // verificar uso de cada app
            //??
            app.UseStatusCodePages();
            //??
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //??
            app.UseRouting();
            //??
            app.UseAuthorization();
            //

            app.UseEndpoints(endpoints =>
            {
                /// Endpoint Controller
                endpoints.MapControllers();
                
            });
        }
    }
}
