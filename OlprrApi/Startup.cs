using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using OlprrApi.Storage;
using OlprrApi.Middlewares;
using OlprrApi.Storage.Repositories;
using OlprrApi.Services;
using AutoMapper;
using OlprrApi.Attributes;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;

namespace OlprrApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                    );
            });

            //services.AddMvc();
            services.AddMvc(options =>
            {
                options.Filters.Add(new ModelValidationFilterAttribute()); 
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                    {
                        Title = "HOL API",
                        Version = "v1",
                    }
                );
                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                //    {
                //        { "Bearer", Enumerable.Empty<string>() },
                //    }
                //);
                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                c.IncludeXmlComments(xmlFile);
            });


            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<LustDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("LustDbConnection1"));
                },
                ServiceLifetime.Scoped
             );
            services.AddScoped<IOlprrRepository, OlprrRepository>();
            services.AddScoped<ILustRepository, LustRepository>();
            services.AddScoped<IIncidentReportingService, IncidentReportingService>();
            services.AddScoped<IOlprrReviewService, OlprrReviewService>();
            services.AddScoped<ILustService,LustService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");
            //app.UseCors("AllowAllHeaders");
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "HOL API");
            });
        }
    }
}

