using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySolution.Domain.Entites;
using CompanySolution.Domain.Interfaces;
using CompanySolution.Infra.Data.Context;
using CompanySolution.Infra.Data.Repository;
using CompanySolution.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CompanySolution
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<CompanySolutionContext>(options => options.UseSqlite(Configuration.GetConnectionString("CompanySolutionConnection")));

            services.AddScoped<IRepository<Phone>, PhoneRepository>();
            services.AddTransient<IService<Phone>, PhoneService>();
            services.AddScoped<IRepository<Company>, CompanyRepository>();
            services.AddTransient<IService<Company>, CompanyService>();
            services.AddScoped<IRepository<Supplier>, SupplierRepository>();
            services.AddTransient<IService<Supplier>, SupplierService>();
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
