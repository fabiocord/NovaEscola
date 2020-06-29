using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NovaEscola.Persistence;
using AutoMapper;
using NovaEscola.Core.Services;
using NovaEscola.Persistence.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NovaEscola.Core.Repositories;
using NovaEscola.Persistence.Repositories;
using NovaEscola.Core;

namespace NovaEscola
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
            services.AddControllers();
            
            services.AddDbContext<NovaEscolaContext>((sp,opt) =>            
            {
                opt.UseNpgsql(Configuration.GetConnectionString("herokuConnectionString"));
            });

            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            services.TryAddScoped<IEscolaService, EscolaService>();
            services.TryAddScoped<ISerieService, SerieService>();
            services.TryAddScoped<ITurmaService, TurmaService>();
                       
            
            services.TryAddScoped<IEscolaRepository, EscolaRepository>();
            services.TryAddScoped<ISerieRepository, SerieRepository>();
            services.TryAddScoped<ITurmasRepository, TurmasRepository>();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
        }
    }
}
