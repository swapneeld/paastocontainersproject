using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaasCRMSystemCoreWeb.DAL;
using Microsoft.EntityFrameworkCore;

namespace PaasCRMSystemCoreWeb
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
            services.AddDbContext<CustomersContext>(
                dbContextOptionsBuilder =>
                {
                    var connectionString = this.Configuration.GetConnectionString("DefaultConnection");

                    if (string.IsNullOrEmpty(connectionString))
                    {
                        connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
                    }

                    if (string.IsNullOrEmpty(connectionString))
                        throw new ApplicationException("Unable to locate Connection String for Back-end Database!");

                    dbContextOptionsBuilder.UseSqlServer(connectionString);
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
