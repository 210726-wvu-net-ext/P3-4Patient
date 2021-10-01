using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FourPatient.Domain;
using FourPatient.DataAccess;
using FourPatient.DataAccess.Entities;

namespace FourPatient.WebAPI
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
            services.AddScoped<IHospital, HospitalRepo>();
            services.AddScoped<IPatient, PatientRepo>();
            services.AddScoped<IReview, ReviewRepo>();
            services.AddScoped<IAccommodation, AccommodationRepo>();
            services.AddScoped<ICleanliness, CleanlinessRepo>();
            services.AddScoped<ICovid, CovidRepo>();
            services.AddScoped<INursing, NursingRepo>();

            services.AddCors(c =>
            {
                c.AddPolicy("YO", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            });


            services.AddControllers();
            services.AddDbContext<_4PatientContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FourPatient.WebAPI", Version = "v1" });
            });

            //services.AddCors(opt =>
            //{
            //    opt.AddPolicy("CorsPolicy", policy =>
            //    {
            //        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200",
            //                                              "http://localhost:44347"
            //        );
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FourPatient.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            //app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
