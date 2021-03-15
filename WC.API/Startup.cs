using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using WC.Context;
using WC.API.Configurations;
using AutoMapper;
using WC.Service.Contracts;
using WC.Service.Implementations;
using WC.Repository.Contracts;
using WC.Repository.Implementations;

namespace WC.API
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
            services.AddAutoMapper(typeof(MapperCongifuration));

            services.AddDbContext<WildCrittersDBContext>(opt => opt.UseMySql(Configuration["ConnectionStrings:Default"]));

            services.AddControllers();

            ConfigureService(services);

            ConfigureRepository(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("WildCritters", new OpenApiInfo()
                {
                    Title = "API WildCritters",
                    Version = "1"
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

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/WildCritters/swagger.json", "API WildCritters"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
        }

        private void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<INoteRepository, NoteRepository>();
        }
    }
}
