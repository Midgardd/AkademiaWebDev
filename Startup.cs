﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using webdev.Algorithms;
using webdev.Interfaces;
using webdev.Repository;

namespace webdev
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
            services.AddMvc();
            //@@rejestrowanie service swaggera:
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "URL Shortener API", Version = "v1" }));
            //@@Zarejestrowanie WarsawDbContext w kontenerze DI oraz przekaz connections string:
            services.AddDbContext<LinkDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LinkDbConnection")));


            services.AddSingleton<ILinksRepository, LinksRepository>();
            services.AddTransient<IHashAlgorithm, HashIdAlgorithm>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Link}/{action=Index}");
            });

            app.UseSwagger();
            //konfiguracja swaggera
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "URL Shortener API"));
        }
    }
}