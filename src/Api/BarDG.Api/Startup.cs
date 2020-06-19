using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarDG.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetDevPack.Identity;

namespace BarDG.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.addIdentity(Configuration);

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("Alpha",
                    new OpenApiInfo
                    {
                        Title = "Bar Do DG API",
                        Version = "Alpha",
                        Description = "Api para fornecer os dados do projeto Bar do DG",
                        Contact = new OpenApiContact
                        {
                            Name = "Victor Ochoa",
                            Url = new Uri("https://github.com/Victor-Ochoa")
                        }
                    });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    BearerFormat = "Bearer ",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                }) ;
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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
            });

            services.AddRepository(Configuration);

            services.AddMediator();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/Alpha/swagger.json", "Bar Do DG - Alpha");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
