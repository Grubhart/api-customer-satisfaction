using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using api_customer_satisfaction.Models;
using api_customer_satisfaction.Models.DataManager;
using api_customer_satisfaction.Models.Repository;
using api_customer_satisfaction.ServiceSoap.ServiceContract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SoapCore;

namespace api_customer_satisfaction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public readonly string soapRest = "_soapRest";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(opts => opts.UseSqlServer(Configuration["ConnectionString:CustomerSatisfaction"]));
            services.AddScoped<IEvaluationService, EvaluationService>();
            services.AddScoped<IDataRepository<Evaluation>, EvaluationManager>();
            services.AddCors(
                options => options.AddPolicy(
                    soapRest, builder =>
                    {
                        builder.WithOrigins("https://localhost:44326/", "https://localhost:44326/EvaluationService.asmx");
                    }));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "api-customer-satisfaction", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "api-customer-satisfaction");
            });

            app.UseSoapEndpoint<IEvaluationService>("/EvaluationService.asmx", new BasicHttpBinding(), SoapSerializer.XmlSerializer);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(op => op.WithOrigins("https://localhost:44326/", "https://localhost:44326/EvaluationService.asmx").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
